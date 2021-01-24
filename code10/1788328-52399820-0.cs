    private readonly Test.Data.MyContext _Context;
    
    public HomeController(Test.Data.MyContext context)
    { _Context = context; }
    
    [HttpGet]
    public ActionResult TypeofAccounts(string at)
    {
    	var result = GetTypeOfAccounts(_Context, at);
    
    	return Json(result);
    }
    
    public static IQueryable<dynamic> GetTypeOfAccounts(Test.Data.MyContext context, string at)
    {
    	var result = context.TypeOfAccounts
    		.Where(x => x.AccountType == at)
    		.Select(x =>
    			new
    			{
    				label = x.AccountType,
    				id = x.AccountType
    			}
    		);
    		
    	return result;
    }
