    private string[] _parametersArray = new string[0];
    
    [Option("parameters")]
    public IEnumerable<string> Parameters
    {
    	get { return _parametersArray; }
    	set { _parametersArray = value.ToArray(); }
    }
    public string[] ParametersArray
    {
    	get { return _parametersArray; }
    }
