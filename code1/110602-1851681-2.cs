    public class Program
    {
        class LoginEntry
        {
            public int UserLoginHistoryID { get; set; }
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
                new LoginEntry {UserLoginHistoryID = 1, CreatedAt = new DateTime(2009, 1, 1, 3, 0 ,0)},
                new LoginEntry {UserLoginHistoryID = 1, CreatedAt = new DateTime(2009, 1, 1, 15, 0 ,0)},
                new LoginEntry {UserLoginHistoryID = 1, CreatedAt = new DateTime(2009, 1, 3, 11, 0 ,0)},
                new LoginEntry {UserLoginHistoryID = 1, CreatedAt = new DateTime(2009, 1, 1, 10, 0 ,0)},
                new LoginEntry {UserLoginHistoryID = 2, CreatedAt = new DateTime(2009, 1, 3, 4, 0 ,0)},
                new LoginEntry {UserLoginHistoryID = 2, CreatedAt = new DateTime(2009, 1, 3, 5, 0 ,0)},
            };
            var result = userLogin.UserLoginClientConnectionHistories
                .GroupBy(y => new { Id = y.UserLoginHistoryID, Day = y.CreatedAt.Date })
                .Select(x => new
                {
                    Id = x.Key.Id,
                    Day = x.Key.Day,
                    MostRecent = x.Max(y => y.CreatedAt)
                });
    
            foreach (var item in result)
            {
                Console.WriteLine("User {0}, day {1}, most recent {2}",
                    item.Id,
                    item.Day,
                    item.MostRecent);
            }
        }
    }
