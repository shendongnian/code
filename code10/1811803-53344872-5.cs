    [HttpGet]
    public IActionResult Play([FromUri] string trackid, [FromUri] string value)
    {   
        if(Session[trackid] == value)
       {
        byte[] b = System.IO.File.ReadAllBytes(trackid + ".ogg");   
         Random rnd = new Random();
         Session[trackid] = rnd.Next(int.MaxValue).ToString();       
        return File(b, "audio/ogg");
       }
    }
 
