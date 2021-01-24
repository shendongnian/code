    [HttpGet("GetValue")]
    [HttpGet("GetValue/{name}/{surname}")]
    public string GetValue(string name,string surname)
    {
    	return "Hi" + name;
    }
