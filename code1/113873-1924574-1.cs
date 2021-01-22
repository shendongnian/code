    var dictionary = new Dictionary<string, List<string>>();
    dictionary.Add("5.72", new List<string> { "a", "bbb", "cccc" });
    dictionary.Add("fifty two", new List<string> { "a", "bbb", "cccc" });
    
    foreach (KeyValuePair<string, List<string>> price in dictionary)
    {
    	double ylevel;
    	if(double.TryParse(price.Key, out ylevel))
    	{
    		//do something with ylevel
    	}
    	else
    	{
    		//Log price.Key and handle this condition
    	}
    }
