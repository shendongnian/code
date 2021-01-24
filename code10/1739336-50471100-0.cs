    void Main()
    {
    	var json = @"{
       ""p"":[
          {
             ""p"":[
                {
                   ""p"":""Get in "",
                   ""f"":[
    
                   ],
                   ""t"":""t""
                },
                {
                   ""p"":""test"",
                   ""t"":""lb"",
                   ""id"":""Make""
                }
             ]
          }
       ]
    }";
    
    	var data = JsonConvert.DeserializeObject<ItemCollection>(json);
    }
    
    public class ItemCollection
    {
    	public ItemGroup[] p { get; set; }
    }
    
    public class ItemGroup
    {
    	public Item[] p { get; set; }
    }
    
    public class Item
    {
    	public string p { get; set; }
    	public string t { get; set; }
    	public string id { get; set; }
    	public string[] f { get; set; }
    }
