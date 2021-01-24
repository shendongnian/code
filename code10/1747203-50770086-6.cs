	class Sport
	{
		protected readonly string typeOfSport;
		protected readonly string coachesName;      
		
		public Sport(string typeOfSport, string coachesName)
		{
			this.typeOfSport = typeOfSport;
			this.coachesName = coachesName;
		}
		public string TypeOfSport
		{
			get { return typeOfSport; }
		}
		public string CoachesName
		{
			get { return coachesName; }
		}
		public override string ToString()
		{
			return "\n" + "\n" +
			   "\nSports Name : " + typeOfSport +
			   "\n" +
			   "\nCoaches Name : " + coachesName;
		}
	}
