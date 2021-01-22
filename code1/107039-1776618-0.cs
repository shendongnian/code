	struct Student
	{
		int Id;
		[MarshalAs(UnmanagedType.LPStr)]
		String Name; 
		Double Marks; 
		public string getStudentName()
		{
			return this.Name;
		}      
		public double getPersantage()
		{
			return this.Marks * 100 / 500;
		}
	}
