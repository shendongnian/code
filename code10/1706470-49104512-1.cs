	public class OrderRepository : IRepository
	{
		public dynamic GetListAsDynamic()
		{
			return new List<Order>
			{
				new Order
				{
					customer = new [] {new Customer { OtherAddress = "1234 Foo St" } }
				}
			};
		}
		public object GetListAsObject()
		{
			return new List<Order>
			{
				new Order
				{
					customer = new [] {new Customer { OtherAddress = "1234 Bar St" } }
				}
			};
		}
	}
