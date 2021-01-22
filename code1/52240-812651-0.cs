    List<string> domains = new List<string>();
    domains.Add("dogstoday.com");
    domains.Add("catstoday.com");
    domains.Add("petstoday.com");
    domains.Add("dogsnow.org");
    domains.Add("dogsabc.net");
    domains.Add("catlitter.info");
    System.Text.RegularExpressions.Regex r = new System.Text.RegularExpressions.Regex("dogs", RegexOptions.IgnoreCase);
    foreach (string domain in domains.Where(d => r.IsMatch(d)))
    {
        Console.WriteLine(domain);
    }
