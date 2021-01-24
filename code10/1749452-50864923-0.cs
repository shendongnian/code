	public class Person
	{
		public string Name { get; set; }
		public string Gender { get; set; }
		public DateTime BirthDate { get; set; }
		
		public int Age 
		{ get { 
			// copied from https://stackoverflow.com/a/1404/1260204
			var today = DateTime.Today;
			var age = today.Year - BirthDate.Year;
			if (birthdate > today.AddYears(-age)) {
				age--;
			}
			return age;
		}}
	}
	
