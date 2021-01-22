        Regex re = new Regex(@"\{(\w*?)\}", RegexOptions.Compiled); // store this...
        string input = "Hi {name}, do you like {food}?";
        Dictionary<string, string> vals = new Dictionary<string, string>();
        vals.Add("name", "Fred");
        vals.Add("food", "milk");
        string q = re.Replace(input, delegate(Match match)
        {
            string key = match.Groups[1].Value;
            return vals[key];
        });
