     //controller
     public class HomeController
    	{
    	  private readonly IDataAccess _dataAccess;
    	  
    	  public HomeController(IDataAccess dataAccess)
    	  {
    		_dataAccess = dataAccess;
    	  }
    	  
    	  [HttpPost]
    	  public ActionResult Index(TblEmployee employee)
    	  {
    	   _dataAccess.AddEmployee(employee);
    		return View();
    	  }
    	}
     // Startup
     public void ConfigureServices(IServiceCollection services)
     {
         // add dependency
    	 services.AddScoped<IDataAccess, EmployeeDataAccessLayer>();
    	 services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
     }
     
     // Data Access Impl
     public class EmployeeDataAccessLayer : IDataAccess 
            {
                private readonly IHttpContextAccessor _httpContextAccessor;
                private IHostingEnvironment _hostingEnvironment;        
    
                public EmployeeDataAccessLayer(IHttpContextAccessor httpContextAccessor)
                {
                    _httpContextAccessor = httpContextAccessor;
                }
                public EmployeeDataAccessLayer(IHostingEnvironment environment)
                {
                    _hostingEnvironment = environment;
                }  
     public void AddEmployee(TblEmployee employee)
            {
                try
                {              
                    string folderName = "UploadFile/";
                    string sPath = "";
                    sPath = Path.Combine(_hostingEnvironment.WebRootPath, "~/" + folderName);
    
                    var hfc = _httpContextAccessor.HttpContext.Request.Form.Files;
               catch{}
          }  
     }
    // interface
    public interface  IDataAccess
    {
     void AddEmployee(TblEmployee employee);
    }
