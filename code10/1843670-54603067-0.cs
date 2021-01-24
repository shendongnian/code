    using (var context = new MusicPlayerContext())
    {
  	    Console.WriteLine("Save PlayList 2 (in context add)");
		context.Playlists.Attach(playlist3);
		playlist3.PlaylistEntries.Add(new PlaylistEntry { 
          FilePath = "Entry3", 
          PlaylistId = playlist3.PlaylistId, PlaylistEntryId = 3 
        });
	    context.SaveChanges();
    }
