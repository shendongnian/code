	public class OrderStatus
	{
		OrderStatus(string display) { this.display = display; }
		string display;
		public override string ToString(){ return display; }
		public static readonly OrderStatus AwaitingAuthorization
			= new OrderStatus("Awaiting Authorization");
		public static readonly OrderStatus InProduction
			= new OrderStatus("Item in Production");
		public static readonly OrderStatus AwaitingDispatch
			= new OrderStatus("Awaiting Dispatch");
	}
