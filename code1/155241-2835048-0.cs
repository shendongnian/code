        static void Main(string[] args)
        {
            string fileName = @"..\..\program.cs";
            var reader = File.OpenText(fileName);
            string line = reader.ReadLine();
            Console.WriteLine("{0} {1}", reader.BaseStream.Position, line);
            reader.BaseStream.Position = reader.BaseStream.Position + 200;  // ignored
            line = reader.ReadLine();
            Console.WriteLine("{0} {1}", reader.BaseStream.Position, line);
            Console.ReadKey();
        }
