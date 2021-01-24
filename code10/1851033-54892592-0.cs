public class User
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public DateTime RegistrationDateTime { get; set; }
        public DateTime LastLoginDateTime { get; set; }
        public bool IsAdmin { get; set; }
        public IEnumerable<Session> Sessions { get; set; }
        public class Session
        {
            //public string Id { get; set; }
            public Guid? Id { get; set; }
            public string UserId { get; set; }
            public User User { get; set; }
            public DateTime StartDateTime { get; set; }
            public DateTime EndDateTime { get; set; }
        }
    }
When sending the value to the service, you must convert it to a string before it is sent:
public User.Session UpsertSession(string userId, Guid? sessionId = null)
        {
            var item = SqlConnection.QuerySingle<User.Session>("[dbo].[UserUpsertSession]",
                new { userId, sessionId = sessionId?.ToString() }, commandType: CommandType.StoredProcedure);
            return item;
        }
