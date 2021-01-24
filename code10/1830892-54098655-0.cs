        [XmlType("supervisor")]
    	public class Supervisor
    	{
    		[XmlAttribute("id")]
    		public string Id { set; get; }
    
    		public string Name { set; get; }
    
    		[XmlElement("Contract")]
    		public int Contracts { set; get; }
    
    		public long Volume { set; get; }
    
    		public int Average { set; get; }
    	}
    
            static void Main(string[] args)
    		{
    			try
    			{
    				XmlSerializer xs = new XmlSerializer(typeof(List<Supervisor>), new XmlRootAttribute("digital-sales"));
    				using (FileStream fileStream = new FileStream(@"C:\temp\ShinDeta.xml", FileMode.Open, FileAccess.Read, FileShare.Read))
    				{
    					var supervisors = xs.Deserialize(fileStream) as List<Supervisor>;
    					foreach (Supervisor supervisor in supervisors)
    					{
    						Debug.WriteLine($"Id: {supervisor.Id}, Name: {supervisor.Name}");
    					}
    				}
    			}
    			catch(Exception e)
    			{
    				Debug.WriteLine(e.Message);
    			}			
    		}
