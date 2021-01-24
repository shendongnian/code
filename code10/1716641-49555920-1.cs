       [HttpGet]
       [Authorize("read_contents")]
       public async Task<IActionResult> GetCotntents(){
     
       }
      [HttpPost]      
      [Authorize("share_content")] 
      public async Task<IActionResult> ShareCotntents(string content){
    
      }
