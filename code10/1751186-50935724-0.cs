    using System;
    using System.Text.RegularExpressions;
    class Program
    {
        static void Main(string[] args)
        {
    
             string r = 
                @"<(?'tag'\w+?).*>"      +   // match first tag, and name it 'tag' 
                @"(?'text'.*?)"          +   // match text content, name it 'textd' 
                @"</\k'tag'>";               // match last tag, denoted by 'tag' 
        
             string text = "<h1>hello</h1>"; 
        
             Match m = Regex.Match (text, r); 
             Console.WriteLine (m.Groups ["tag"]);                // h1 
             Console.WriteLine (m.Groups ["text"]);               // hello 
        }
    }
