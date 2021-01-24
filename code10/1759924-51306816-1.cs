	public class UniProgram
	{
		public string Programme { get; set; }
		public Degree Degree { get; set; }
		public UniProgram(string programme)
		{
			this.Programme = programme;
		}
		
        // Second constructor so you can also define degree
        // : this(...) allows you to call other constructor so either can be used
		public UniProgram(string programme, string degree) : this (programme)
		{
			this.Degree = new Degree(degree);
		}
	}
