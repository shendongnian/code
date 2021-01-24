    public class IndexModel : PageModel
    {
        private readonly Test.Data.MyContext _Context;
        public IndexModel(Test.Data.MyContext context)
        { _Context = context; }
    
        public void OnGet()
        {
            // Here I want bind HomeController's action.
    		var ta = Test.Controllers.HomeController.GetTypeOfAccounts(_Context, "B001");
        }
    }
