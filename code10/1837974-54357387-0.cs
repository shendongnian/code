cs
private static IEnumerable<string> GetStringsBetweenDelimiters(string str, char delimiter)
{
    int openingIndex = default; //index of the opening delimiter
    int closingIndex = -1; //starts from -1 as otherwise it would not work for string
                           //starting with delimiter
    while (true)
    {
        openingIndex = str.IndexOf(delimiter, closingIndex + 1);
        //it has to be +1'd as otherwise it would return closingIndex
        if (openingIndex < 0) yield break; //No more delimiters
        closingIndex = str.IndexOf(delimiter, openingIndex + 1);
        //+1'd for same reason as above
        if (closingIndex < 0) //No closing delimiter
            throw new InvalidOperationException("The given string has odd number of delimiters.");
        //Might just break as well?
        yield return str.Substring(openingIndex + 1, closingIndex - openingIndex - 1);
    }
}
When called like `GetStringsBetweenDelimiters(str, '|')`, this method would only return the values between two pipe characters. Advantage of this method over string.Split(delimiter) is that it would not allocate unnecessary substrings that are not in between the pipe characters (`You can cancel free of charge until `, ` before check-in. You’ll be charged `...), and perhaps a bit simpler to use.
Test:
cs
foreach (string str in GetStringBetweenDelimiters(testStr, '|'))
{
    Console.WriteLine(str);
}
prints
720
407.74USD
720
