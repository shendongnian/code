    public static class Helper
    {
    
      public static JArray GetData(List<string> udata)
      {
          if(udata == null)
             throw new ArgumentException("Data is null");
    
          //do some processing and calclulations here
          //throw ArgumentException if there is an issue
    
       }
     } 
    [HttpPost("data")]
    public async Task<IActionResult> PostData(List<string> udata)
    {
     JArray sets = new JArray();
     try
     {
        sets = Helper.GetData(udata);
        return Ok(sets);
     }
     catch (ArgumentException e)
     {
       return BadRequest(e.Message);
     }
    }
