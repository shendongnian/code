    void Main()
    {
    	var c = new CustomData()
    	{
    		MRecordList = new List<UserQuery.Record>
    		{
    		  new Record{FirstName="A",LastName="B"},
    		  new Record{FirstName="C",LastName="D"}
    		},
    		ResponseCode = "0",
    		Status = ""		
    	};
    	   	
    	JsonConvert.SerializeObject(c).Dump();
    }
    
    
    public class CustomData
    {
    	public List<Record> MRecordList { get; set; }
    	public string ResponseCode { get; set; }
    	public string Status { get; set; }
    }
    
    public class Record
    {
    	public string FirstName { get;set;}    	
    	public string LastName { get;set;}
    }
