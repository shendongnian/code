    public class TestController : Controller
    {
        private readonly Func<DbContext> dbContext;
        public Controller(Func<DbContext> ctx)
        {
            dbContext = ctx;
        }
        public async Task<IActionResult> Test(string id)
        {
            using(var cntx = dbContext())
            {
            var isValid = new otherClass(cntx).Validate(id);
            if (!isValid)
            {
                return View("error");
            }
            var user = cntx.Users.FirstOrDefault(x => x.Id == id);
            user.Age++;
            cntx.SaveChanges();  
            return View();
        }
        }
    }
