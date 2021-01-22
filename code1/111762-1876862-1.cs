    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
    using HtmlAgilityPack;
    
    class Program
    {
        static void Main(string[] args)
        {
            string html = @"<html><body><td class=""blah"" ...........>Some text blah: page 13 of 99<br> more stuff</td></body></html>";
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);
            var nodes = doc.DocumentNode.SelectNodes("//td[@class='blah']");
            if (nodes != null)
            {
                var td = nodes.FirstOrDefault();
                if (td != null)
                {
                    Match match = Regex.Match(td.InnerText, @"page \d+ of (\d+)");
                    if (match.Success)
                    {
                        Console.WriteLine(match.Groups[1].Value);
                    }
                }
            }
        }
    }
