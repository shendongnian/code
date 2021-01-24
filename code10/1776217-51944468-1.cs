    public class Junction
	{
		// foreign keys; composite primary key
		public int ProductId { get; set; }
		public int EnumId { get; set; }
		public int PartId { get; set; }
		public virtual Product Product { get; set; }
		public virtual Enumeration Enumeration { get; set; }
		public virtual Part Part { get; set; }
	}
