    using System;
    using System.IO;
    using System.Text;
    
    class Test 
    {
        public static void Main() 
        {
            try 
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StreamReader sr = new StreamReader(
                    "TestFile.txt",
                    Encoding.UTF8
                    ))
                {
                    const int bufferSize = 1000; //could be anything
                    char[] buffer = new char[bufferSize];
                    // Read from the file until the end of the file is reached.
                    while (bufferSize = sr.Read(buffer, bufferSize, 0)) 
                    {
                        //successfuly decoded another buffer's-worth of data
                    }
                }
            }
            catch (Exception e) 
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
    }
