        public ActionResult GetEmpName()  
        {  
            return Content("This is the test Message");  
        }  
  
        [ActionName("GetEmpWithCode")]  
        public ActionResult GetEmpName(string EmpCode)  
        {  
            return Content("This is the test Messagewith Overloaded");  
        }  
  
    }  
