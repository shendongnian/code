	public class PersonModel
	{
		public DateTime BirthDate { get; set; }
		public int Age { get; set; } // should be computed and mapped from sql
		public bool IsTeenager { get; set; } // should be computed and mapped from sql
	}
	
