	public class Customer{
	
		[JsonIgnore]
		public string FirstName{get;set;}
		[JsonIgnore]
		public string LastName{get;set;}
		[JsonProperty("data")]
		public string[] FullName {get { return new string[]{FirstName, LastName}; } } 
		
		public Customer(string FirstName, string LastName){
		 	this.FirstName = FirstName;
			this.LastName = LastName;
		}
	}
    public static void Main(string[] args)
    {
        Customer c = new Customer("Adrian", "i6");
		
		Console.Write(JsonConvert.SerializeObject(c));
    }
