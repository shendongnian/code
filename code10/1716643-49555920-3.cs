       [HttpGet]
       [Authorize("readcontents")]
       public async Task<IActionResult> GetCotntents(){
     
       }
      [HttpPost]      
      [Authorize("shared")] 
      public async Task<IActionResult> ShareCotntents(string content){
    
      }
