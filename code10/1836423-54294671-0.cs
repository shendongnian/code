    void Main()
    {
    	string jsonString = @"{  
       ""buttonList"":[
          {  
             ""Name"":""TableOverview"",
    		 ""Fast"":false         
          },
          {
             ""Name"":""Evaluation""
    	  }
       ],
       ""FavoritGraphic"":""PDFreport"",
       ""FavoritText"":""Findings""
    }";
    
    
    	ButtonSettingsModel ButtonSettings = GetObjectFromJson<ButtonSettingsModel>(jsonString);
    	//ButtonSettings.Dump();
    }
    
    // Define other methods and classes here
    public class ButtonSettingsModel
    {
    	public readonly string FavoritText;
    	public readonly string FavoritGraphic;
    	public readonly List<ButtonInfo> ButtonList;
    
    	public ButtonSettingsModel(string favoritText, string favoritGraphic, List<ButtonInfo> buttonList)
    	{
    		FavoritText = favoritText;
    		FavoritGraphic = favoritGraphic;
    		ButtonList = buttonList;
    	}
    }
    
    public class ButtonInfo
    {
    	public readonly string Name;
    	public readonly bool Fast;
    
    	public ButtonInfo(string name, bool fast)
    	{
    		Name = name;
    		Fast = fast;
    	}
    }
    
    public T GetObjectFromJson<T>(string jsonString) // correct json
    {
    	var foo = JsonConvert.DeserializeObject<T>(jsonString); // List != null
    	return foo;
    }
