    [HttpGet]
    [HttpGet("{name}/{surname}")]
    public string GetValue(string name,string surname)
    {
    	return "Hi" + name;
    }
