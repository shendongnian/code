        [HttpGet]
        public ActionResult<TestModel> Get()
        {
	        var l =  new TestModel { Num = 0, TotalCost = 1 };
	        _ = l.Avg;
	
	        return l;
        }
