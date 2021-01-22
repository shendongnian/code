    using System;
    using System.IO;
    
    class Test 
    {
        
        public static void Main() 
        {
            string path = @"C:/test.txt";
    
            try 
            {
                if (File.Exists(path)) 
                    File.Delete(path);
    
                using (StreamReader sr = new StreamReader(path)) 
                {
                    while (sr.Peek() >= 0) 
                    {
                        Console.Write((char)sr.Read());
                        // Here check if is a number, space or what else
                        // and use it ^^
                    }
                }
            } 
            catch (Exception e) 
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
        }
    }
