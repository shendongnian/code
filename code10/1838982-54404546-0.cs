string pattern = @"(?<=^|&)(\w+)(?==)=(\w+)(?=&?)";
string input = @"abc=123&ABC=456&abc=789";
Dictionary<string, string> parameters = new Dictionary<string, string>();
foreach (Match m in Regex.Matches(input, pattern))
{
    if (parameters.ContainsKey(m.Groups[1].Value))
    {
        //preserve original behaviour, i.e. concat values of same parameters
        parameters[m.Groups[1].Value] = parameters[m.Groups[1].Value] + "," + m.Groups[2].Value;
    } else
    {
        parameters.Add(m.Groups[1].Value, m.Groups[2].Value);
    }
}
This might fail with Unicode parameters outside of `a-zA-Z0-9_` so you might have to edit the regex to fit your needs.
