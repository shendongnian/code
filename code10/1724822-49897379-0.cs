        Match match = Regex.Match(input, @"content/([A-Za-z0-9\-]+)\.aspx$",
            RegexOptions.IgnoreCase);
        // Here we check the Match instance.
        if (match.Success)
        {
            // Finally, we get the Group value and display it.
            string key = match.Groups[1].Value;
            Console.WriteLine(key);
        }
