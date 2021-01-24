	public class CustomerAndAddressModel
	{
		public long Id { get; set; }
	
		public string UserName { get; set; }
		
		public string Address { get; set; }
	
		public string Address2 { get; set; }
	
		public string City { get; set; }
	
		public string State { get; set; }
	
		public string ZIP { get; set; }
		public Customer ToCustomer()
		{
			return new Customer
			{
				Id = Id,
				UserName = UserName,
				Address = new AddressModel
				{
					Address = Address,
					Address2 = Address2,
					City = City,
					State = State,
					ZIP = ZIP
				}
			};
		}
		public static CustomerAndAddressModel FromCustomer(Customer customer)
		{
			return new CustomerAndAddressModel
			{
				Id = customer.Id,
				UserName = customer.UserName,
				Address = customer.Address.Address,
				Address2 = customer.Address.Address2,
				City = customer.Address.City,
				State = customer.Address.State,
				ZIP = customer.Address.ZIP
			};
		}
	}
