    class Program
    {
        static void Main(string[] args)
        {
            var developer = new { Name = "Jason Bowers" };
            PrintDeveloperName(developer.DuckCast<IDeveloper>());
            Console.ReadKey();
        }
        private static void PrintDeveloperName(IDeveloper developer)
        {
            Console.WriteLine(developer.Name);
        }
    }
    public interface IDeveloper
    {
        string Name { get; }
    }
