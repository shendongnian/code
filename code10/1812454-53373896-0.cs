   	public static void Main()
	{
		
		List<MP3objectSmall> songs = new List<MP3objectSmall>();
		
		songs.Add(new MP3objectSmall(){SongName ="a"});
		songs.Add(new MP3objectSmall(){SongName ="b"});
		songs.Add(new MP3objectSmall(){SongName ="x"});
		songs.Add(new MP3objectSmall(){SongName ="z"});
		
		string letter = "x";
		
		MP3objectSmall  firstSong = songs.FirstOrDefault(x => x.SongName.ToLowerInvariant().StartsWith(letter));
		
		if(firstSong != null)
		{
			int index = songs.IndexOf(firstSong);
			Console.WriteLine(index);
		}
	}
