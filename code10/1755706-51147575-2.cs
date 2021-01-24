    public static class MyServiceLocator
    {
        public static IServiceProvider Instance { get; set; }
    }
    
    public void Configure(IApplicationBuilder app)
    {
        MyServiceLocator.Instance = app.ApplicationServices;
    }
    
    
     // Data Access
     public class EmployeeDataAccessLayer  
            {         
    
            public void AddEmployee(TblEmployee employee)
            {
                try
                {      
    
                    IHttpContextAccessor httpContextAccessor =MyServiceLocator.Instance.GetService<IHttpContextAccessor>();
                    IHostingEnvironment hostingEnvironment=MyServiceLocator.Instance.GetService<IHostingEnvironment>();; 
    
    			
                    string folderName = "UploadFile/";
                    string sPath = "";
                    sPath = Path.Combine(_hostingEnvironment.WebRootPath, "~/" + folderName);
    
                    var hfc = _httpContextAccessor.HttpContext.Request.Form.Files;
               } 
    		  catch{}
    		}
    }	
