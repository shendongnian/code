	public static void Main()
	{	
		var Id = 4;
		var all = GetAllPersons();
		
		var t = all
		   .Where(x => x.Id == Id)
		   .Select(P => new Person()
					{ 
						Id = P.Id, 
						Files = P.Files.Where(l => l.FileType == 1).ToList()
					})
		   .Where(y => y.Files.Count > 0)
		   .FirstOrDefault();
	}
