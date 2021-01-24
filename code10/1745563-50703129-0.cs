        string sample = "ab\tcefÖ";
        string pattern = "(\\t)|(Ö)";
        string result = Regex.Replace(sample, pattern, "");
        System.Console.WriteLine("SAMPLE : " + sample);
        System.Console.WriteLine("RESULT : " + result);
