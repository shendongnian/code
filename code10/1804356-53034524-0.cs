    class Program
    {
        static void Main(string[] args)
       {
        var reader = new StreamReader(File.OpenRead(@"C:\Users\Vitor\Downloads\LogCombustivel.csv"));
        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            var values = line.Split(',');
            if (values.Any( x=> x == "Honda"))
            {
                Console.WriteLine(line);
            }
        }
        Console.ReadLine();
        }
    }
