    public class Program
    {
        class LoginEntry
        {
            public DateTime CreatedAt { get; set; }
        }
    
        class UserLogin
        {
            public List<LoginEntry> UserLoginClientConnectionHistories = new List<LoginEntry>();
        }
    
        public static void Main(string[] args)
        {
            UserLogin userLogin = new UserLogin();
            userLogin.UserLoginClientConnectionHistories = new List<LoginEntry> {
                new LoginEntry {CreatedAt = new DateTime(2009, 1, 1, 3, 0 ,0)},
                new LoginEntry {CreatedAt = new DateTime(2009, 1, 1, 15, 0 ,0)},
                new LoginEntry {CreatedAt = new DateTime(2009, 1, 3, 11, 0 ,0)},
                new LoginEntry {CreatedAt = new DateTime(2009, 1, 1, 10, 0 ,0)},
            };
            var result = userLogin.UserLoginClientConnectionHistories
                .GroupBy(y => y.CreatedAt.Date)
                .Select(x => new { Day = x.Key, MostRecent = x.Max(y => y.CreatedAt) });
    
            foreach (var item in result)
            {
                Console.WriteLine("Day {0}, most recent {1}", item.Day, item.MostRecent);
            }
        }
    }
