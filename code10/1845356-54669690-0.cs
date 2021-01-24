    namespace ConsoleApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<string> _names = new List<string>()
                {
                    "Rehan",
                    "Hamza",
                    "Adil",
                    "Arif",
                    "Hamid",
                    "Hadeed"
                };
    
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(@"E:\test.txt")))
                {
                    foreach (string line in _names)
                        outputFile.WriteLine(line);
                }
            }
        }
    }
