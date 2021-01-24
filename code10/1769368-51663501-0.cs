    public class Location
    {
        public string Name { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
    private static void Main()
    {
        var locations = new List<Location>();
        var maxLength = 5;
        // Populate our list with locations that have an ever growing Name length
        for (int i = 0; i < 10; i++)
        {
            locations.Add(new Location {Name = new string('*', i)});
        }
        Console.WriteLine("Beginning values:");
        locations.ForEach(Console.WriteLine);
        // Trim the values
        locations.ForEach(l => l.Name = string.Concat(l.Name.Take(maxLength)));
        Console.WriteLine("\nEnding values:");
        locations.ForEach(Console.WriteLine);
        GetKeyFromUser("\nDone! Press any key to exit...");
    }
