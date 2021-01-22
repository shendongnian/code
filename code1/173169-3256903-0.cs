	public void Main (string[] args)
	{
		var films = ToList(new [] {
			new {Name = "Jaws", Year = 1975},
			new {Name = "Singing in the Rain", Year = 1952},
			new {Name = "Some Like It Hot", Year = 1959},
			new {Name = "The Wizard of Oz", Year = 1939},
			new {Name = "It's a Wonderful Life", Year = 1946},
			new {Name = "American Beauty", Year = 1999},
			new {Name = "High Fidelity", Year = 2000},
			new {Name = "The Usual Suspects", Year = 1995}
		}
		);
		
		films.ForEach(f => Console.Write(f.Name + " - " + f.Year));
	}
	public List<T> ToList<T> (IEnumerable<T> list)
	{
		return new List<T>(list);
	}
