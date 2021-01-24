        string[] tests = {"\uF200", "\uF201", "\uF2FF", "\uF100", "\uFFFF"};
        const string regexPattern = @"[\uF200-\uF2FF]";
        Regex rx = new Regex(regexPattern,RegexOptions.Compiled | RegexOptions.IgnoreCase);
        foreach (string test in tests)
        {
            if(rx.IsMatch(test))
                Console.WriteLine("{0} is within the range.",test);
            else
                Console.WriteLine("{0} is not within the range.",test);
        }
        foreach(string test in tests)
        {
            Console.WriteLine("The corresponding decimal value of " + test + " is: " + int.Parse(test, System.Globalization.NumberStyles.HexNumber));
        }
