    class Program
    {
        static void Main(string[] args)
        {
            XDocument doc = XDocument.Load(@"Path to your xml file");
            List<long> tinList = new List<long>();
            tinList = doc.Descendants("Participants").Elements().Elements("TIN").Select(x => (long)x).ToList();
            foreach (long tin in tinList)
            {
                Console.WriteLine(tin);
            }
            Console.ReadLine();
        }
    }
