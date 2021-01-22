    namespace Example
    {
        using System;
        using System.Net;
        using System.IO;
        using System.Text.RegularExpressions;
    
        public class MyExample
        {
            public static string GetDirectoryListingRegexForUrl(string url)
            {
                if (url.Equals("http://www.ibiblio.org/pub/"))
                {
                    return "<a href=\".*\">(?<name>.*)</a>";
                }
                throw new NotSupportedException();
            }
            public static void Main(String[] args)
            {
                string url = "http://www.ibiblio.org/pub/";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        string html = reader.ReadToEnd();
                        Regex regex = new Regex(GetDirectoryListingRegexForUrl(url));
                        MatchCollection matches = regex.Matches(html);
                        if (matches.Count > 0)
                        {
                            foreach (Match match in matches)
                            {
                                if (match.Success)
                                {
                                    Console.WriteLine(match.Groups["name"]);
                                }
                            }
                        }
                    }
                }
    
                Console.ReadLine();
            }
        }
    }
