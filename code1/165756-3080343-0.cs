	[DelimitedRecord(",")]
	public class Customer
	{
		public int CustId;
		
		public string Name;
		public decimal Balance;
		[FieldConverter(ConverterKind.Date, "dd-MM-yyyy")]
		public DateTime AddedDate;
	}	
