    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Net;
    using System.IO;
    using System.Text.RegularExpressions;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                string page = @"http://stackoverflow.com/";
                HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(page);
                StreamReader SR = new StreamReader(req.GetResponse().GetResponseStream());
    
                Char[] buf = new Char[256];
                int count = SR.Read(buf, 0, 256);
                while (count > 0)
                {
                    String outputData = new String(buf, 0, count);
                    Match match = Regex.Match(outputData, @"<title>([^<]+)", RegexOptions.IgnoreCase);
                    if (match.Success)
                    {
                        Console.WriteLine(match.Groups[1].Value);
                    }
                    count = SR.Read(buf, 0, 256);
                }
            }
    
        }
    }
