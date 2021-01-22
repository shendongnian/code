    void Main()
    {
    	var items = new[] { new MyObj { MyProperty = "ABC123" },
    						new MyObj { MyProperty = "123ABC" },
    						new MyObj { MyProperty = "123ABC456" },
    	};
    	
    	var matches = items.MatchesWildcard(item => item.MyProperty, "???ABC");
    }
    
    public class MyObj
    {
    	public string MyProperty {get;set;}
    }
