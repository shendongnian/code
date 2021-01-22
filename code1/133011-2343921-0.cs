    using System;
    using System.Collections.Generic;
    using System.Text;
    using Word;
    
    namespace ConsoleApplication1
    {
        class Program
        {
    
            static void Main(string[] args)
            {
                
                // Find the full path of our document
    
                System.IO.FileInfo ExecutableFileInfo = new System.IO.FileInfo(System.Reflection.Assembly.GetEntryAssembly().Location);            
                object docFileName = System.IO.Path.Combine(ExecutableFileInfo.DirectoryName, "document.doc");
    
                // Create the needed Word.Application and Word.Document objects
    
                object nullObject = System.Reflection.Missing.Value;
                Word.Application application = new Word.ApplicationClass();
                Word.Document document = application.Documents.Open(ref docFileName, ref nullObject, ref nullObject, ref nullObject, ref nullObject, ref nullObject, ref nullObject, ref nullObject, ref nullObject, ref nullObject, ref nullObject, ref nullObject);
    
    
                string wholeTextContent = document.Content.Text; 
                wholeTextContent = wholeTextContent.Replace('\r', ' '); // Delete lines between paragraphs
                string[] splittedTextContent = wholeTextContent.Split(' '); // Get the separate words
    
                int index = 1;
                foreach (string singleWord in splittedTextContent)
                {
                    if (singleWord.Trim().Length > 0) // We don´t need to store white spaces
                    {
                        Console.WriteLine("Word: " + singleWord + "(position: " + index.ToString() + ")");
                        index++;
                    }
                }
    
                // Dispose Word.Application and Word.Document objects resources
    
                document.Close(ref nullObject, ref nullObject, ref nullObject);
                application.Quit(ref nullObject, ref nullObject, ref nullObject);
                document = null;
                application = null;
                
                Console.ReadLine(); 
            }
        }
    }
