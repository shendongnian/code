    using System;
    using System.IO;
    
    class Test 
    {
    	
        public static void Main() 
        {
            string path = @"c:\temp\MyTest.txt";
            try 
            {
                if (File.Exists(path)) 
                {
                    
                
    
                using (StreamReader sr = new StreamReader(path)) 
                {
                    while (sr.Peek() >= 0) 
                    {
                        string s = sr.ReadLine();
                         string [] split = s.Split(';');
                         
                         //now loop through split array
                         //split[0] is server
                        // split[1] is user id
                    }
                }
              }
            } 
            catch (Exception e) 
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
        }
    }
