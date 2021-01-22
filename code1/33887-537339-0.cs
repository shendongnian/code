    using System;
    using System.Net;
    
    class Program
    {
        static void Main()
        {
            string word = "How to ask";
            string source = (new WebClient()).DownloadString("http://stackoverflow.com/");
            if(source.Contains(word))
                Console.WriteLine("Found it " + word);
        }
    }
