      [HttpGet]
        public List<MyList> GetResults()
        {
               return  Webservice.GetResults().ToList().ToMyCustomType();
    
        
        } 
