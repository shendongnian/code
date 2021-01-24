    [HttpGet]
    public IActionResult GetVideoContent() {
        if (Program.TryOpenFile("BigBuckBunny.mp4", FileMode.Open, out FileStream fs)) {        
            return new FileStreamResult(fs, new MediaTypeHeaderValue("video/mp4").MediaType);
        }
         
        return BadRequest();
    }
    
