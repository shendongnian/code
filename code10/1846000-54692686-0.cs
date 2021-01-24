	public class SalesOrder
	{
		public DateTime OrderDate { get; set; }
		public int OrderNumber { get; set; }
		public byte OrderType { get; set; }
		public string DespatchDate { get; set; }
		public string AccountReference { get; set; }
		public string CustomerOrderNumber { get; set; }
		public string Name { get; set; }
		public double TotalAmount { get; set; }
		public string Allocated { get; set; }
		public string Despatched { get; set; }
		public bool Printed { get; set; }
	}
