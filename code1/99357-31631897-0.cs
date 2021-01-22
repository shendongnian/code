    public static List<string> SplitTheSentenceAtWord(this string originalString, int length)
        {
            try
            {
                List<string> truncatedStrings = new List<string>();
                if (originalString == null || originalString.Trim().Length <= length)
                {
                    truncatedStrings.Add(originalString);
                    return truncatedStrings;
                }
                int index = originalString.Trim().LastIndexOf(" ");
                while ((index + 3) > length)
                    index = originalString.Substring(0, index).Trim().LastIndexOf(" ");
                if (index > 0)
                {
                    string retValue = originalString.Substring(0, index) + "...";
                    truncatedStrings.Add(retValue);
                    string shortWord2 = originalString;
                    if (retValue.EndsWith("..."))
                    {
                        shortWord2 = retValue.Replace("...", "");
                    }
                    shortWord2 = originalString.Substring(shortWord2.Length);
                    if (shortWord2.Length > length) //truncate it further
                    {
                        List<string> retValues = SplitTheSentenceAtWord(shortWord2.TrimStart(), length);
                        truncatedStrings.AddRange(retValues);
                    }
                    else
                    {
                        truncatedStrings.Add(shortWord2.TrimStart());
                    }
                    return truncatedStrings;
                }
                var retVal_Last = originalString.Substring(0, length - 3);
                truncatedStrings.Add(retVal_Last + "...");
                if (originalString.Length > length)//truncate it further
                {
                    string shortWord3 = originalString;
                    if (originalString.EndsWith("..."))
                    {
                        shortWord3 = originalString.Replace("...", "");
                    }
                    shortWord3 = originalString.Substring(retVal_Last.Length);
                    List<string> retValues = SplitTheSentenceAtWord(shortWord3.TrimStart(), length);
                    truncatedStrings.AddRange(retValues);
                }
                else
                {
                    truncatedStrings.Add(retVal_Last + "...");
                }
                return truncatedStrings;
            }
            catch
            {
                return new List<string> { originalString };
            }
        }
