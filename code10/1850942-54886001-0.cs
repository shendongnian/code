       private static void ListFileInDirectory(string workingDirectory)
        {
            string[] filePaths = Directory.GetFiles(workingDirectory);
            String line;
            foreach (string filePath in filePaths)
            {
                Console.WriteLine(filePath);
                try
                {
                  //it returns string[]
                 var allText = System.IO.File.ReadAllLines(filePath);//opens a text file, reads all text and closes the text file.
                 foreach(var str in allText)
                 {
                   //Do what you want.
                 }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
                finally
                {
                    Console.WriteLine("Executing finally block.");
                }
            }
        }
