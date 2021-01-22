    using System;
    using System.Collections.Generic;
    using System.IO;
    namespace SearchWebsite
    {
    internal class NetDomain
    {
        static public string GetDomainFromUrl(string Url)
        {
            return GetDomainFromUrl(new Uri(Url));
        }
        static public string GetDomainFromUrl(string Url, bool Strict)
        {
            return GetDomainFromUrl(new Uri(Url), Strict);
        }
        static public string GetDomainFromUrl(Uri Url)
        {
            return GetDomainFromUrl(Url, false);
        }
        static public string GetDomainFromUrl(Uri Url, bool Strict)
        {
            initializeTLD();
            if (Url == null) return null;
            var dotBits = Url.Host.Split('.');
            if (dotBits.Length == 1) return Url.Host; //eg http://localhost/blah.php = "localhost"
            if (dotBits.Length == 2) return Url.Host; //eg http://blah.co/blah.php = "localhost"
            string bestMatch = "";
            foreach (var tld in DOMAINS)
            {
                if (Url.Host.EndsWith(tld, StringComparison.InvariantCultureIgnoreCase))
                {
                    if (tld.Length > bestMatch.Length) bestMatch = tld;
                }
            }
            if (string.IsNullOrEmpty(bestMatch))
                return Url.Host; //eg http://domain.com/blah = "domain.com"
            //add the domain name onto tld
            string[] bestBits = bestMatch.Split('.');
            string[] inputBits = Url.Host.Split('.');
            int getLastBits = bestBits.Length + 1;
            bestMatch = "";
            for (int c = inputBits.Length - getLastBits; c < inputBits.Length; c++)
            {
                if (bestMatch.Length > 0) bestMatch += ".";
                bestMatch += inputBits[c];
            }
            return bestMatch;
        }
        static private void initializeTLD()
        {
            if (DOMAINS.Count > 0) return;
            string line;
            var reader = File.OpenText("effective_tld_names.dat");
            while ((line = reader.ReadLine()) != null)
            {
                if (!string.IsNullOrEmpty(line) && !line.StartsWith("//"))
                {
                    DOMAINS.Add(line);
                }
            }
        }
        // This file was taken from https://publicsuffix.org/list/effective_tld_names.dat
        static public List<String> DOMAINS = new List<String>();
    }
}
