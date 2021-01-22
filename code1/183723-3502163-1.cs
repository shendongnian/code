    class Program
            {
                static void Main()
                {
                    string str = "Eternal (woman)";
                    string[] s = str.Split('(');
    
                    string newString = string.Empty;
                    foreach (string sUpper in s)
                    {
                        newString += UppercaseFirst(sUpper);
                    }
                     newString = newString.Replace(" " ," (");
                }
    
                static string UppercaseFirst(string s)
                {
                    // Check for empty string.
                    if (string.IsNullOrEmpty(s))
                    {
                        return string.Empty;
                    }
                    // Return char and concat substring.
                    return char.ToUpper(s[0]) + s.Substring(1);
                }
            }
