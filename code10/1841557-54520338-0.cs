    public class Data
    {
    	public string Status { get; set; }
    	[JsonProperty("PROJECT@odata.bind")]
    	public string[] Projects { get; set; }
    }
	var json = JsonConvert.SerializeObject(new Data
    { 
        Status = "New", 
        Projects = new string[] {$"/PROJECT('{prjBarcode}')" } 
    });
