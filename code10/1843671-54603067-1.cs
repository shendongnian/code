   	using (var context = new MusicPlayerContext())
   	{
		Console.WriteLine("Save PlayList 2 (full attach)");
		context.Playlists.Attach(playlist2);
		context.Entry(playlist2).State = EntityState.Modified;
		context.Entry(playlist2.PlaylistEntries.First()).State = EntityState.Added;
		context.SaveChanges();
    }
