    string s = File.ReadAllText("input.txt");
    string empty = "buildLetter.Append(\"\").AppendLine();" + Environment.NewLine;
    s = s.Replace(empty, "");
    s = Regex.Replace(s, @"(?<="").*(?="")",
             match => { return match.Value.Replace("\"",  "\\\""); }
        );
