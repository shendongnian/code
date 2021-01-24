    static string ReadDataPairFromConsole( string DataName )
    {
        Console.Write("Enter {0}: ", DataName );
        return FirstLetterUpper(Console.ReadLine());
    }
