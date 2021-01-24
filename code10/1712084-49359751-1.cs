    [ResponseCache(NoStore = true)]
    public IActionResult Index() {
        
        Thread.Sleep(5000);
        return Ok("test");
    }
