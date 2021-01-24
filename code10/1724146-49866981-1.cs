	public static void Main()
	{	
		var Id = 4;
		var all = GetAllPersons();
		
		var t = all
		   .Where(x => x.Id == Id)
		   .Where(y => y.Files.Any(l => l.FileType == 1))
		   .Select(P => new Person()
					{ 
						Id = P.Id, 
						Files = P.Files.Where(l => l.FileType == 1).ToList()
					})
		   .FirstOrDefault();
	}
