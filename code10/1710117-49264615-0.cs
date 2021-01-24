    public static void SeedNewSingerAndSong(AppContext context)
    {
        ...
        // Assign songs to new Singer
        newSinger.Songs.Add(foundExistingSong);
        newSinger.Songs.Add(foundNewSong);
        // Assign Singer to Songs
        foundExistingSong.Singers.Add(newSinger);
        foundfoundNewSong.Singers.Add(newSinger);
        // The following duplicates "New Song" as explained in *Additional Info
        context.Singers.AddOrUpdate(
            item => item.Name,
            newSinger
        );
        context.SaveChanges();
    }
