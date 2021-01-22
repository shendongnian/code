        using System;
        using System.Net;
        using System.IO;
    
    public class Test
    {
        public static void Main (string[] args)
        {
            
            WebClient client = new WebClient ();
    
            Stream data = client.OpenRead (args[0]);
            StreamReader reader = new StreamReader (data);
            string s = reader.ReadToEnd ();
            Console.WriteLine (s);
            data.Close ();
            reader.Close ();
        }
    }
