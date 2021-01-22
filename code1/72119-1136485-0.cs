        var keys = new HashSet<string>();
        Regex.Replace(input, "(@@[^@]+@@)", match => {
            keys.Add(match.Groups[1].Value);
            return ""; // doesn't matter
        });
        foreach (string key in keys) {
            Console.WriteLine(key);
        }
