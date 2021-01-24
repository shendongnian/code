	public class Test
	{
		// make it a private setter so people don't try to set the property
		// without validation
		public DateTime DateOfBirth
		{
			get;
			private set;
		}
		// validation is probably best done outside of a property
		public void SetDateOfBirth(DateTime dateOfBirth)
		{
			if (dateOfBirth.Year > DateTime.Now.Year - 16)
			{
				throw new ArgumentOutOfRangeException("dateOfBirth", "Date of birth year cannot be after : " + (DateTime.Now.Year - 16));
			}
			DateOfBirth = dateOfBirth;
		}
		public Test()
		{
		}
		// if you really want one stage construction,
		// lets call the common DoB validation
		public Test(DateTime dateOfBirth)
		{
			SetDateOfBirth(dateOfBirth);
		}
	}
