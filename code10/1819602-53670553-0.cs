    public class EncryptedData
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string Data { get; set; }
    	
    	public bool ShouldSerializeData()
    	{
    		// don't serialize the Data property if the Type equals "encrypted"
    		return (Type != "encrypted");
    	}
    }
