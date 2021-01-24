    static Song InputSongDetails()
    {
        Console.WriteLine("What is the name of your song");
        string name = Console.ReadLine();
        Console.WriteLine(name)
    
        Console.WriteLine("What is the artists name");
        string artist = Console.ReadLine();
        Console.WriteLine(artist)
    
        int records;
        Console.WriteLine("How many records did it sell");
        while (!int.TryParse(Console.ReadLine(), out records) || records < 0)
        {
            Console.WriteLine("That is not valid please enter a number");
        }
        Console.WriteLine(records)
        return new Song(name, artist, records);
    }
