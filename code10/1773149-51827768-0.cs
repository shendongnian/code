	void Main()
	{
		var data = new List<CowOutput> {
			new CowOutput {CowID = 1, DateOfMilking = new DateTime(2018, 7, 30), NumberOfMilkInLtr = 1.2F },
			new CowOutput {CowID = 1, DateOfMilking = new DateTime(2018, 7, 31), NumberOfMilkInLtr = 1.3F },
			new CowOutput {CowID = 1, DateOfMilking = new DateTime(2018, 8,  5), NumberOfMilkInLtr = 1.5F },
			new CowOutput {CowID = 1, DateOfMilking = new DateTime(2018, 8,  6), NumberOfMilkInLtr = 1.1F },
			new CowOutput {CowID = 1, DateOfMilking = new DateTime(2018, 8,  7), NumberOfMilkInLtr = 1.7F },
			new CowOutput {CowID = 1, DateOfMilking = new DateTime(2018, 8,  8), NumberOfMilkInLtr = 1.4F },
			new CowOutput {CowID = 2, DateOfMilking = new DateTime(2018, 7, 30), NumberOfMilkInLtr = 1.4F },
			new CowOutput {CowID = 3, DateOfMilking = new DateTime(2018, 7, 31), NumberOfMilkInLtr = 1.1F },
			new CowOutput {CowID = 2, DateOfMilking = new DateTime(2018, 8,  1), NumberOfMilkInLtr = 1.8F },
			new CowOutput {CowID = 5, DateOfMilking = new DateTime(2018, 8,  2), NumberOfMilkInLtr = 1.4F },
			new CowOutput {CowID = 6, DateOfMilking = new DateTime(2018, 8,  3), NumberOfMilkInLtr = 1.2F },
			new CowOutput {CowID = 2, DateOfMilking = new DateTime(2018, 8,  5), NumberOfMilkInLtr = 1.5F },
			new CowOutput {CowID = 1, DateOfMilking = new DateTime(2018, 6,  5), NumberOfMilkInLtr = 1.5F },
		};
	
		var cowId = 1;
		var days = 4;
	
	
		var cowData = data
			.Where(d => d.CowID == cowId)
			.OrderBy(d => d.DateOfMilking);
	
		cowData
			.Zip(
				cowData.Skip(1), 
				(current, next) =>
				{
					next.Group = (next.DateOfMilking.Subtract(current.DateOfMilking).TotalDays >= days)
						? current.Group + 1
						: current.Group ;
					return next;
				})
			.GroupBy(d => d.Group)
			.Select(d => d.ToList())
			.ToList()
			.Dump(); // I'm using LinqPad to test this. You can remove this and just use the output.
	}
	
	public class CowOutput
	{
		public Int32 CowID { get; set; }
		public DateTime DateOfMilking { get; set; }
		public Single NumberOfMilkInLtr { get; set; }
		public Int32 Group { get; set; }
	}
