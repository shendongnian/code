    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using CommandLine;
    using CommandLine.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
        static int Main(string[] args)
        {
            string input = @"bla bla bla bla bla bla Feature
    bla bla bla bla bla bla bla bla
    
    Feature
    
    bla bla bla bla bla
    
    ""bla bla bla bla bla blabla bla 
    bla bla bla bla bla"" Feature bla bla bla bla 
    
    Feature 
    
    bla bla bla bla bla
    
    ""bla bla bla bla bla blabla bla 
    bla bla bla bla bla bla bla bla bla ";
            //Matches:
            //  Any line starting with Feature (with optional whitespace)                   ^\s*Feature
            //  followed by newline (with optional whitespace)                              \s*\r\n
            //  then capturing anything that isn't a quote "                                ([^""]*)
            //  then ending with a quote                                                    \""
            Regex r = new Regex(@"^\s*Feature\s*\r\n([^""]*)\""",RegexOptions.Singleline | RegexOptions.Multiline);
            List<string> paragraphs = new List<string>();
            foreach (Match match in r.Matches(input))
                paragraphs.Add(match.Groups[1].Value.Trim());
            for (int i = 0; i < paragraphs.Count; i++)
                Console.WriteLine("Paragraph [{0}] - {1}", i, paragraphs[i]);
            Console.Read();
            return 0;
        }
    }
    }
