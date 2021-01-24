    void Main()
    {
    	string json = @"{
       ""permissions"": {
                ""user"": [
                    ""Add"",
                    ""Update"",
                    ""Delete""
                ],
                ""Product"": [
                    ""Read"",
                    ""Create""
                ]
            }
    }";
    
        var root = Root.FromJson(json);
    	
    	Console.WriteLine("C# Object");
    	Console.WriteLine("Permissions:");
    	Console.WriteLine("\tUser:[");
    	foreach (var v in root.Permissions.User)
    	{
    		Console.WriteLine($"\t\t{v}");
    	}
    	Console.WriteLine("\t]");
    	Console.WriteLine("\tProduct:[");
    	foreach (var v in root.Permissions.Product)
    	{
    		Console.WriteLine($"\t\t{v}");
    	}
    	Console.WriteLine("\t]");
    
    
        Console.WriteLine("As JSON string");
    	Console.WriteLine(root.ToJson());
    }
    
    [JsonConverter(typeof(StringEnumConverter))]
    public enum UserAction { 
    	Add,
    	Update,
    	Delete
    }
    
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ProductAction
    {
    	Read,
    	Create
    }
    
    public partial class Root
    {
    	[JsonProperty("permissions")]
    	public Permissions Permissions { get; set; }
    
    	public static Root FromJson(string json) => JsonConvert.DeserializeObject<Root>(json);
    	public string ToJson() => JsonConvert.SerializeObject(this);
    }
    
    public class Permissions
    {
    	[JsonProperty("user")]
    	public List<UserAction> User { get; set ; }
    
    	[JsonProperty("Product")]
    	public List<ProductAction> Product { get; set; }
    }
