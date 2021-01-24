	public class PersonModel
	{
		public DateTime BirthDate { get; set; }
		public int Age
		{
			get
			{
				var today = DateTime.Today;
				// Calculate the age.
				var age = today.Year - BirthDate.Year;
				// Go back to the year the person was born in case of a leap year
				if (BirthDate > today.AddYears(-age)) age--;
				return age;
			}
		}
		public bool IsTeenager
		{
			get
			{
				return Age >= 13 && Age < 20;
			}
		}
	}
	
