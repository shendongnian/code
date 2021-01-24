	private Family FamilyTestCase(string fileName, bool save)
	{           
		if (save)
		{
			var people = new List<Person>()
			{
				new Person("Angus", GenderType.Male),
				new Person("John", GenderType.Male),
				new Person("Katrina", GenderType.Female),           
			};
			var fam = new Family(people, people[0]);
			var famSer = new FamilySerializer(fam);
			famSer.Save(fileName);
			return fam;
		}
		else
		{
			var famSer = new FamilySerializer();
			famSer.Open(fileName);
			if (Object.ReferenceEquals(fam.People[0], fam.FamilyHead))
			{
				Console.WriteLine("Family head is the same than People[0]!");
			}
			return famSer.Family;
		}
	}
