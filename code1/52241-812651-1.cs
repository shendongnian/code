    string line;
    System.Text.RegularExpressions.Regex r = new System.Text.RegularExpressions.Regex("dogs", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
    using (System.IO.StreamReader reader = System.IO.File.OpenText("domains.txt"))
    {
        while ((line = reader.ReadLine()) != null)
        {
            if (r.IsMatch(line))
            {
                Console.WriteLine(domain);
            }
        }
    }
