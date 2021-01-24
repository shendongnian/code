    [HttpGet]
    [Route("GetValues")]
    [Route("GetValues/{name}/{surname}")]
    public string GetValue(string name,string surname)
    {
        return "Hello " + name + " " + surname;
    }
