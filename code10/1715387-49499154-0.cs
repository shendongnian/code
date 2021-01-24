    public class Customer
    {
        //JsonProperty is Used to serialize as a different property then your property name
	    [JsonProperty(PropertyName = "Customer")] 
        public Dictionary<string, Data> CustomerDictionary { get; set; }
    }
    public class Data
    {
        public string Id { get; set; } //You should make this "Id" not "id"
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
