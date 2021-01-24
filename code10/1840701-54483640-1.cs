    static Song InputSongDetails()
    {
		var song = new Song();
        Console.WriteLine("What is the name of your song");
        song.Name = Console.ReadLine();
        Console.WriteLine("What is the artists name");
        song.Artist = Console.ReadLine();
        int records;
        Console.WriteLine("How many records did it sell");
        while (!int.TryParse(Console.ReadLine(), out records))
        {
            Console.WriteLine("That is not valid please enter a number");
        }
		song.Records = records;
        string returns = String.Format("Your song is{0}, the artists name is {1} and it sold {2} records", song.Name, song.Artist, song.Records);
		
        return song;
    }	
