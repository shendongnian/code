    void Main()
    {
    	var list = new List<string>();
    	
    	var dictionary = new Dictionary<string,object>();
    	
    	var isTrue = list is IEnumerable<object>;
    	
    	isTrue.Print(); // Prints True
    	
    	isTrue = dictionary is IDictionary<object,object>;
    	
    	isTrue.Print(); // Prints False
        isTrue = dictionary is IEnumerable<KeyValuePair<object,object>>;
	    isTrue.Print(); // Prints False, KeyValuePair<string,object> is not same as KeyValuePair<object,object>
	    isTrue = dictionary is IEnumerable<KeyValuePair<string, object>>;
	    isTrue.Print(); // Prints True
    }
