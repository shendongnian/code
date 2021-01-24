    public interface ISeedDataClass
    {
        void InitializeDbForTests();
    }
    public class SeedDataClass : ISeedDataClass
    {
        private readonly GatewayContext _db;
        public SeedDataClass(GatewayContext db)
        {
            _db = db;
        }
        public void InitializeDbForTests()
        {
            _db.Users.AddRange(
                // add some users here
            );
            _db.SaveChanges(true);
        }
    }
