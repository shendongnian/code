    public class ConnectionListParser : OptionSet
    {
    	public class ConnectionSettings
    	{
    		public string Name { get; set; }
    		public string Servername { get; set; }
    		public string Username { get; set; }
    		public string Password { get; set; }
    	}
    	
    	public List<ConnectionSettings> Connections {get;} = new List<ConnectionSettings>();		
    	
    	public ConnectionListParser() {		
    		Add("<>", x => {						
    			Connections.Add(new ConnectionSettings() {
    				Name = x
    			});								
    		});
    	
    		Add("s:", x => Connections.Last().Servername = x);
    		Add("u:", x => Connections.Last().Username = x);
    		Add("p:", x => Connections.Last().Password = x);
    	}
    }
