    void Main()
    {
    	var msf = new People() {
    		Parts = new List<Parts> {
    			new Parts { Name = "Lqlq", Id = "234567", Data = new Dictionary<string, string> { { "Number", "1"} } },
    			new Parts { Name = "Lqlq2", Id = "3424242", Data = new Dictionary<string, string> { { "Number", "2"} } },
    		}
    	};
    	var temp = from part in msf.Parts
    		where part.Data["Number"] == "2"
    		select part
    	;
    	   
    	temp.Dump();
    }
    
    public class People
    {
    	public List<Parts> Parts { get; set; }
    }
    
    public class Parts
    {
       public string Name { get; set; }
       public string Id { get; set; }
       public Dictionary<string, string> Data { get; set; }
    }
