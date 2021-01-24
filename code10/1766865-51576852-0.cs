	void Main()
	{
		IList<Customer>  AllCustomers;
		IList<Hotel>      Hotels;
		
		var reg = from h in Hotels
		          join c in AllCustomers on h.HotelRegistration equals c.Name
				  select h;
		
		
	}
	class Customer
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public string description { get; set; }
	}
	
	class Hotel
	{
		public int ID { get; set; }
		public string HotelRegistration  { get; set; }
		public string description { get; set; }
	}
