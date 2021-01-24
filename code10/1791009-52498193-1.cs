    class Program
    {
        static void Main(string[] args)
        {
            Feedback feedback = new Feedback();
            var xml = System.IO.File.ReadAllText(@"C:\Users\Nullplex6\source\repos\ConsoleApp4\ConsoleApp4\Files\XMLFile1.xml");
            var serializer = new XmlSerializer(typeof(Feedback));
            using (var reader = new StringReader(xml))
            {
                feedback = (Feedback)serializer.Deserialize(reader);
            }
    
            Console.WriteLine($"Organization: {feedback.MetaData.Organisation}");
            Console.ReadLine();
        }
    }
