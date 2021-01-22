    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text.RegularExpressions;
    
    class Program
    {
        static void Main(string[] args)
        {
            using (var client = new WebClient())
            {
                var directories = client.DownloadString("http://example.com/root");
                var latestVersion = GetVersions(directories).Max();
                if (latestVersion != null)
                {
                    // construct url here for latest version
                    client.DownloadFile(...);
                }
            }
        }
    
        static IEnumerable<Version> GetVersions(string directories)
        {
            var regex = new Regex(@"<a href=""[^""]*/([0-9]+\.[0-9]+\.[0-9])+/"">",
                RegexOptions.IgnoreCase);
    
            foreach (Match match in regex.Matches(directories))
            {
                var href = match.Groups[1].Value;
                yield return new Version(href);
            }
            yield break;
        }
    }
