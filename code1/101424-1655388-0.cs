    using System;
    using System.Net;
    using System.Text.RegularExpressions;
    class Program
    {
        private const string url =
            "http://stackoverflow.com/questions/1655313/get-the-static-text-contents-of-a-web-page";
        private const string keyword = "question";
    
        private const string regexTemplate = ">([^<>]*?{0}[^<>]*?)<";
        static void Main(string[] args)
        {
            WebClient client = new WebClient();
            string html = client.DownloadString(url);
            Regex regex = new Regex(string.Format(regexTemplate,keyword) , RegexOptions.IgnoreCase);
            var matches = regex.Matches(html);
            foreach (Match match in matches)
                Console.WriteLine(match.Groups[1].Value);
        }
    }
