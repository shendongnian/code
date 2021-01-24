	public class Program
	{
		public static void TestDynamic()
		{
			var repo = new OrderRepository();
			var orders = repo.GetListAsDynamic();
			var order = orders[0];
			var customers = order.customer;
			var customer = customers[0];
			
			Console.WriteLine("And the customer dynamic's other address is.... '{0}'", customer.OtherAddress);
		}
	
		public static void TestObject()
		{
			var repo = new OrderRepository();
			var orders = repo.GetListAsObject() as List<Order>;
			var order = orders[0];
			var customers = order.customer;
			var customer = customers[0];
			
			Console.WriteLine("And the customer object's other address is.... '{0}'", customer.OtherAddress);
		}
		
		public static void Main()
		{
			TestDynamic();
			TestObject();
		}
	}
