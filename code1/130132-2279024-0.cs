    static class FluentManager
	{
		public static T WithFirstName<T>(this T person, string firstName) where T : FluentPerson
		{
			person.FirstName = firstName;
			return person;
		}
		public static T WithId<T>(this T customer, long id) where T : FluentCustomer
		{
			customer.ID = id;
			return customer;
		}
	}
	class FluentPerson
	{
		public string FirstName { private get; set; }
		public string LastName { private get; set; }
		public override string ToString()
		{
			return string.Format("First name: {0} last name: {1}", FirstName, LastName);
		}
	}
	class FluentCustomer : FluentPerson
	{
		public long ID { private get; set; }
		public long AccountNumber { private get; set; }
		public override string ToString()
		{
			return base.ToString() + string.Format(" account number: {0} id: {1}", AccountNumber, ID);
		}
	}
