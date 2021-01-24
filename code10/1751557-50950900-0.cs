    public class Player
    {
    	public string steamid { get; set; }
    	public int communityvisibilitystate { get; set; }
    	public int profilestate { get; set; }
    	public string personaname { get; set; }
    	public ulong lastlogoff { get; set; }
    	public int commentpermission { get; set; }
    	public string profileurl { get; set; }
    	public string avatar { get; set; }
    	public string avatarmedium { get; set; }
    	public string avatarfull { get; set; }
    	public int personastate { get; set; }
    	public string realname { get; set; }
    	public string primaryclanid { get; set; }
    	public ulong timecreated { get; set; }
    	public int personastateflags { get; set; }    
    }
    	
    public class Response
    {
    	public Player[] players { get; set; }
    }
    
    public class EncapsulatedResponse
    {
    	public Response response {get;set;}
    }
    
    internal static void DeserilizeJson()
    {
    	string json = GetUrlToString("http://api.steampowered.com/ISteamUser/GetPlayerSummaries/v0002/?key=xxxxxxxxxxxxxxxxxxxxx&steamids=xxxxxxxxxxxxxxx");
    	Console.WriteLine(json);
    	EncapsulatedResponse info = JsonConvert.DeserializeObject<EncapsulatedResponse>(json);
    
    	using (StreamWriter file = File.CreateText(@"c:\test.json"))
    	{
    		JsonSerializer serializer = new JsonSerializer();
    		serializer.Serialize(file, info);
    	}
    }
