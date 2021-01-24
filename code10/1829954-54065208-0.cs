    class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Version { get; set; }
    
        public Person()    { 
        }
    	
    	public static Person Get(int id) {
    		// here would be an RPC call to get the FirstName,LastName,Version. result is JSON
    		
    		string json = "{\"result\": {\"version\":1,\"Id\": 1, \"FirstName\": \"Bob\", \"LastName\": \"Jones\"},\"error\":null,\"id\":\"getperson\"}";
    		
    		dynamic jObject = JObject.Parse(json);	
    		
    		var person = jObject.result.ToObject<Person>();
    
    		return person;
    	}
    }
