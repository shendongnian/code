	class Song
	{
		public string Name { get; private set; }
		public LinkedList<Note> notes { get; private set; }
		public Song(string name)
		{
			this.Name = name;
			this.notes = new LinkedList<Note>();
		}
	}
