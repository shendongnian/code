private static string[] digitnames = new string[] 
    { "oh", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};
private static string ReplaceDigits(string s)
{
    string convertedSoFar = ""; //could use a StringBuilder if performance is an issue.
    for (int charPos = 0; charPos &lt; s.Length; charPos++)
    {
        if (char.IsNumber(s[charPos]))
        {
            //Add the digit name matching the digit.
            convertedSoFar += digitnames[int.Parse(s[charPos].ToString())];
        }
        else
        {
            //we've reached the end of the numbers at the front of the string. 
            //Add back the rest of s and quit.
            convertedSoFar += s.Substring(charPos);
            break;
        }
    }
    return convertedSoFar;
}
