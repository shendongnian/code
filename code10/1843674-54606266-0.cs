    var playlist = new Playlist { Name = "My first playlist" };
    using (var context = new MusicPlayerContext(stringBuilder))
    {
        context.Playlists.Add(playlist);
    }
    
    playlist.PlaylistEntries.Add(new PlaylistEntry { FilePath = "Song7" });
    playlist.PlaylistEntries.Add(new PlaylistEntry { FilePath = "Song8" });
    using (var context = new MusicPlayerContext(stringBuilder))
    {
        context.Playlists.Add(playlist);
        context.Entry(playlist).State = EntityState.Modified;
        foreach (var entry in playlist.PlaylistEntries)
        {
            context.Entry(entry).State = entry.PlaylistEntryId == 0 ? EntityState.Added : EntityState.Modified;
        }
        context.SaveChanges();
    }
    using (var context = new MusicPlayerContext(stringBuilder))
    {
        context.Playlists.Include(x => x.PlaylistEntries).ToList();
    }
