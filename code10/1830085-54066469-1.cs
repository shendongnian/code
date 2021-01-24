    internal class Program
    {
        private static void Main(string[] args)
        {
            var usersDao = new Repo<UsersDo>(new UserContext());
            var r = usersDao.Find(x => x.Username == "username");
        }
    }
