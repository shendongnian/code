         public class JsonDemoController : Controller  
         {  
            #region ActionControllers  
      
             /// <summary>  
            /// Get department data in Json Format  
            /// </summary>  
            /// <returns></returns> 
                
            public JsonResult GetDepartmentJsonData()  
            {  
                var departments= GetDepartments();  
                return Json(departments, JsonRequestBehavior.AllowGet);  
            }
    
     
            private List<Department> GetDepartments()  
            {  
                var departmentList = new List<Department>  
                {  
                    new Department  
                    {  
                        DepartmentId = 1,  
                        Title = "Finance",  
                        Children = childrenCollection
                    }  
                   
                };  
      
                return departmentList;  
            }     
         }  
 
