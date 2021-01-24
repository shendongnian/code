    public class MyService
    {
        private readonly IAbpSession _session;
    
        public MyService(IAbpSession session)
        {
            _session = session;
        }
    
        public void Test()
        {
            using (_session.Use(42, null))
            {
              var defaultUsers = _userTeamsRepository
                .GetAllIncluding(ut => ut.Team, ut => ut.User)
                .Where(ut => ut.Team.AlwaysIncluded)
                .ToList();
            }
        }
    }
