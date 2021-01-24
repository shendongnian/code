    public class TransHelper
    {
    	public string Key { get; set; }
    	public string Translation { get; set; }
    }
    
    public static void Main()
    {
    	var myList = new List<TransHelper> {
    		new TransHelper { Key = "K1", Translation = "T1" },
    		new TransHelper { Key = "K2", Translation = "T2" },
    		new TransHelper { Key = "K3", Translation = "T3" }
    	};
    
    	var dict = myList.ToDictionary(t => t.Key, t => t.Translation);
    	//Serialize dict to Json using Newtonsoft.Json (JSON.Net) or Utf8Json libraries
    }
