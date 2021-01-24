    class Shelve
	{
		public int Id {get;set;}
		public string Name {get;set;}
		public List<Book> Books {get;set;} = List<Book>();
		public int Cost 
        {
            get{ return this.Books.Sum(x => x.Cost); } 
        }
	}
