        public IActionResult Index()
        {
            return View();
        }
    
        [HttpPost]
        public void Store([FromBody]MyObject obj)
        {
            Console.WriteLine(Request.Body);
            //Some code
        }
        // If you have a parameter from the uri or query-string, you can add it to the Template this way
        [HttpGet("{objectUID} ")]
        public void Check(string objectUID, string idfv)
        {
            Console.WriteLine($"ObjectUID: {objectUID}");
            Console.WriteLine($"IDFV: {idfv}");
            //some other code
        }
        // Or optional parameter like this 
        [HttpGet ("{objectUID?} ")]
        public MyObject Retrieve(string objectUID)
        {
            Console.Writeline($"ObjectUID: {objectUID}");
            //Some Code
        }
    }
