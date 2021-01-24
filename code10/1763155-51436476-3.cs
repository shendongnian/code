    class Library
	{
		public int Id {get;set;}
		public string Name {get;set;}
		public List<Shelve> Shelves {get;set;} = new List<Shelve>();
		public int Cost 
        {
            get{ return this.Shelves.Sum(x => x.Cost); } 
        }
	}
