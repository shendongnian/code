        internal class Program
        {
            private static void Main(string[] args)
            {
                // Open a doc file.
                Application application = new Application();
                Document document = application.Documents.Open("C:\\temp\\word.doc");
    
                // Loop through all words in the document.
    
                int k = 1;
    
                int count = document.Words.Count;
                for (int i = 1; i <= count; i++)
                {
                    // Write the word.
                    string text = document.Words[i].Text.Trim();
    
                    if (!string.IsNullOrEmpty(text))
                    {
                        Console.WriteLine("Word {0} = {1}", k, text);
                        k++;
                    }
                }
    
                Console.ReadLine();
                // Close word.
                application.Quit();
            }
