    List<string> list = new List<string>()
    {
       "abc234",
       "asdf234324",
       "adc234-b"
    };
    Match m;
    foreach (string s in list)
    {
       m = Regex.Match(s, "^(?<firstPart>[a-z]+)(?<secondPart>(.+))$");
       Console.WriteLine(String.Format("First Part = {0}", m.Groups["firstPart"].Value));
       Console.WriteLine(String.Format("Second Part = {0}", m.Groups["secondPart"].Value));
    }
