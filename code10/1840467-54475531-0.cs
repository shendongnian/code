    [HttpGet]
        public List<MyList> GetResults()
        {
                var result = Webservice.GetResults().ToList();
    
    
    
   
        return results.Select(xx=> new MyList{ // ,-- HERE YOU CAN ALSO USE A GENERIC NEW
                      newTitle = result.Title + " - my custom value",
                      newData = "01/01/2019",
                      newLink = GetCustomLink(result)
                  }).ToList()
        
        } 
