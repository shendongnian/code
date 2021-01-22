    using System.Text.RegularExpressions;
    ...
    string empid = "E123";   // <-- example input
    var empidPattern = new Regex(@"^E(?<NumericPart>\d{3})$");
    if (empidPattern.IsMatch(empid))
    {
        // extract numeric part from key and convert it to int:
        int numericPart = Int32.Parse(
                              empidPattern.Match(empid).Groups["NumericPart"].Value);
    }
    else
    {
        // 'empid' does not represent a valid key (wrong format)
    }
