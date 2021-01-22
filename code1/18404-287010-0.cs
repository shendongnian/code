        StringBuilder sb = new StringBuilder("{");
        bool first = true;
        foreach (Match match in Regex.Matches(html, @"test\((""[^\""]*\"")\)"))
        {
            if(first) {first = false;}
            else {sb.Append(',');}
            sb.Append(match.Groups[1].Value);
        }
        sb.Append('}');
        Console.WriteLine(sb);
