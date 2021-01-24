    public HomeController 
    {
        [HttpGet]
        public string ActionMethod()
        {
            var address = this.Request.HttpContext.Connection.RemoteIpAddress;
        }
    }
