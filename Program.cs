using System;

namespace UserManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(UserManager.Login("nika1998", "123")); //false
            //User user1 = new User();
            //user1.Username = "nika1998";
            //user1.Password = "123";
            //Console.WriteLine(UserManager.Register(user1)); //0
            //Console.WriteLine(UserManager.Register(user1)); //-2
            //User user2 = new User() { Username = "Nino9796", Password = "9796" };
            //Console.WriteLine(UserManager.Register(user2)); //0
            //Console.WriteLine(UserManager.Login("nika1998", "123")); //true
            //Console.WriteLine(UserManager.Login("nika1998", "111")); //false
            //Console.WriteLine(UserManager.UnRegister("nikusha1998")); //false
            //Console.WriteLine(UserManager.UnRegister("nika1998")); //true
            //Console.WriteLine(UserManager.Login("nika1998", "123")); //false
        }
    }
    class User
    {
        private string _username;
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                if (value.Length < 8)
                {
                    throw new Exception("Username length should be more than 8");
                }
                _username = value;
            }
        }
        public string Password { get; set; }
    }
    static class UserManager
    {
        static private User[] _users = new User[1];
        static public int Register(User u)
        {
            if (u.Username == null || u.Password == null)
            {
                return -1;
            }
            for (int i = 0; i < _users.Length; i++)
            {
                if (_users[i] != null && u.Username == _users[i].Username)
                {
                    return -2;
                }
            }
            for (int i = 0; i < _users.Length; i++)
            {
                if (_users[i] == null)
                {                   
                    _users[i] = u;
                    Resize(ref _users, _users.Length + 1);
                    break;
                }
            }
            return 0;
        }
        static public bool Login(string username, string password)
        {
            for (int i = 0; i < _users.Length; i++)
            {
                if (_users[i] != null && _users[i].Username == username && _users[i].Password == password)
                {
                    return true;
                }
            }
            return false;
        }
        static public bool UnRegister(string username)
        {
            for (int i = 0; i < _users.Length; i++)
            {
                if (_users[i] != null && _users[i].Username == username)
                {
                    _users[i] = null;
                    return true;
                }
            }
            return false;
        }
        public static void Resize(ref User[] array, int newSize)
        {
            User[] temp = new User[newSize];
            int size = Math.Min(array.Length, newSize);
            for (int i = 0; i < size; i++)
            {
                temp[i] = array[i];
            }
            array = temp;
        }
    }
}
