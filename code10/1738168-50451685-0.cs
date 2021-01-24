    public static string Replacement(this Match match, string replacePattern)
    {
            if (replacePattern.Contains("$"))
            {
                //there is substitutes
                string result = replacePattern;
                for (int i = 1; i < match.Groups.Count; i++)
                {
                    //Group[0] is the full match, so start with each captured group
                    result = result.Replace("$" + i.ToString(), match.Groups[i].Value);
                }
                return result;
            }
            else
            {
                //no substitutes
                return replacePattern;
            }
    }
