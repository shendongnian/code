    static readonly Regex re = new Regex(@"\{([^\}]+)\}", RegexOptions.Compiled);
    static void Main()
    {
        string input = "this {foo} is now {bar}.";
        StringDictionary fields = new StringDictionary();
        fields.Add("foo", "code");
        fields.Add("bar", "working");
        string output = re.Replace(input, delegate (Match match) {
            return fields[match.Groups[1].Value];
        });
        Console.WriteLine(output); // "this code is now working."
    }
