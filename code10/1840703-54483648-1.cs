    using System;
    using System.Dynamic;
    namespace Songs
    {
    class Program
    {
        static void Main(string[] args)
        {
            dynamic[] ArrayOfSongs = new dynamic[4];
            for (var i = 0; i < ArrayOfSongs.Length; i++)
            {
                ArrayOfSongs[i] = InputSongDetails();
            }
            Console.ReadLine();
        }
        static dynamic InputSongDetails()
        {
            dynamic returnObj = new ExpandoObject();
            Console.WriteLine("Enter an artists name, or press return for all artists");
            Console.WriteLine("What is the name of your song");
            string name = Console.ReadLine();
            returnObj.name = name;
            Console.WriteLine("What is the artists name");
            string artist = Console.ReadLine();
            returnObj.artist = artist;
            Console.WriteLine("How many records did it sell");
            string recordsStr = Console.ReadLine();
            int records;
            while (!Int32.TryParse(recordsStr, out records) || records < 0)
            {
                Console.WriteLine("try again");
                recordsStr = Console.ReadLine();
            }
            returnObj.records = records;
            Console.WriteLine($"Your song is{name}, the artists name is {artist} and it sold {records.ToString()} records");
            return returnObj;
        }
    }
}
