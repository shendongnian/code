    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    
    namespace Vaktliste.Controllers
    {
        public class MyBaseControllerClass : Controller
        {
            public readonly int branchId;
            protected int BranchId { 
                get { HttpContext.Session?.GetInt32("BranchId")?.Value ?? 0; }
                set { HttpContext.Session.SetInt32("BranchId", value); }
            }
            
            public MyBaseControllerClass()
            {
                
            }
        }
    }
