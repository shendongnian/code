     public class AllowedToEmailFunc
    {
        private static Func<long, EmailPermit> CreatePermit;
        public class EmailPermit
        {
            public static void AllowIssuingPermits()
            {
                IssuegPermit = (long userId) =>
                {
                    return new EmailPermit(userId);
                };
            }
            public readonly long UserId;
            private EmailPermit(long userId) 
            {
                UserId = userId;
            }
        }
        static AllowedToEmailFunc()
        {
            EmailPermit.AllowIssuingPermits();
        }
        public static bool AllowedToEmail(UserAndConf user)
        {
            var canEmail = true; /// code checking if we can email the user
            if (canEmail)
            {
                return IssuegPermit(user.UserId);
            }
            else
            {
                return null
            }
        }
    }
