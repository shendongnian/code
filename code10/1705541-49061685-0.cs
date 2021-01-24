    namespace Week_3_Opdracht_3
    {
        class Program
        {
            public static List<string> streamReaderResults = new List<string>();
    
    
            private static string currentFileLine;
    
            static void Main(string[] args)
            {
    
                StreamReader opdrachtDrieFile = new StreamReader(@"C:\Users\sande\Documents\VisualStudio school\.txt files to read\Opdracht 3 tekst.txt");
    
                while ((currentFileLine = opdrachtDrieFile.ReadLine()) != null)
                {
                    //nothing yet.
                }
                Console.ReadKey();
            }
        }
    }
