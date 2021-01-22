    static readonly Regex re = new Regex(@"\$(\w+)\$", RegexOptions.Compiled);
    static void Main() {
        string input = @"Dear $name$, as of $date$ your balance is $amount$";
        var args = new Dictionary<string, string>(
            StringComparer.OrdinalIgnoreCase) {
                {"name", "Mr Smith"},
                {"date", "05 Aug 2009"},
                {"amount", "GBP200"}
            };
        string output = re.Replace(input, match => args[match.Groups[1].Value]);
    }
