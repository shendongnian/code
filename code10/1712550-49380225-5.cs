    public class ContactController
    {
        private YourDbContext _db;
        public ContactController(YourDbContext db)
        {
             _db = db;
        }
        [EnableQuery()] //You don't actually need this because we added a filter in ConfigureServices
        public IActionResult Get()
        {
            //Always return an IQueryable
            return Ok(_db.Contacts.AsQueryable());
        }
        //Add PUT, PATCH and DELETE if needed...
    }
