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
                    for (int index = 0; index < _names.Count; index++)
                    {
                        outputFile.WriteLine("Index : " + index + " - " + _names[index]);
                    }
                }
            }
        }
    }
