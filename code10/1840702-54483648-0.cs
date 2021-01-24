    namespace Songs
    {
    class Program
    {
        static void Main(string[] args)
        {
            string[] ArrayOfSongs = new string[4];
            for(var i = 0; i < ArrayOfSongs.Length; i++)
            {
                ArrayOfSongs[i] = InputSongDetails();
                Console.WriteLine(ArrayOfSongs[i]);
            }
            Console.ReadLine();
        }
          static string InputSongDetails()
          {
              Console.WriteLine("Enter an artists name, or press return for all artists");
              Console.WriteLine("What is the name of your song");
              string name = Console.ReadLine();
              Console.WriteLine("What is the artists name");
              string artist = Console.ReadLine();
              Console.WriteLine("How many records did it sell");
              string recordsStr = Console.ReadLine();
              int records;
              while (!Int32.TryParse(recordsStr, out records) || records < 0)
              {
                  Console.WriteLine("try again");
                  recordsStr = Console.ReadLine();
              }
             return $"Your song is{name}, the artists name is {artist} and it sold {records.ToString()} records";
           
          }
    }
}
