    using System;
    
    public class Test
    {
        static void Main(string[] args)
        {
            string[,] strings = new string[2,2];
            // Just to make things absolutely explict
            strings[0,0] = "0,0";
            strings[0,1] = "0,1";
            strings[1,0] = "1,0";
            strings[1,1] = "1,1";
            
            foreach (string x in strings)
            {
                Console.WriteLine(x);
            }
        }
    }
