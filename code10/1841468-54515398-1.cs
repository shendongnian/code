    Console.WriteLine("Enter an artist name, or just press return for all artists");
    var name = Console.ReadLine();
    foreach (var song in songs)
    {
        if (song.GetArtist() == name || name == "")
        {
            Console.WriteLine(song.GetDetails());
        }
    }
