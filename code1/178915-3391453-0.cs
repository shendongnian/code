    public class TeamRepository : GenericRepository<Team, AppDataContext>
    {
        public TeamRepository() : base() { }
        public TeamRepository(AppDataContext db) : base(db) { }
    }
