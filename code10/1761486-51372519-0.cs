	class Song
	{
		public string Name;
		public LinkedList<Note> notes;
		public Song(string name)
		{
			this.Name = name;
			this.notes = new LinkedList<Note>();
		}
	}
