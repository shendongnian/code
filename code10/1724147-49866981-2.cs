    static List<Person> GetAllPersons()
	{
		var ret = new List<Person>(new [] 
								{ 
									new Person(){ Id = 10 }, 
									new Person(){ Id = 4 },
									new Person(){ Id = 8 }
								});
		
		var rnd = new Random();
		
		foreach(var person in ret)
			for(int i = 0; i <3; i++)
				person.Files.Add(new File() { FileType = rnd.Next(1,3) , Name= "File " + (i + 1).ToString() });
			
		return ret;
	}
	
	class Person
	{
		public int Id { get; set; }
		public List<File> Files { get;set; }
		
		public Person()
		{
			Files = new List<File>();
		}
	}
	
	class File
	{
		public int FileType { get; set; }
		public string Name { get; set; }
	}
