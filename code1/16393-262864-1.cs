    public static string DigitsOnly(string inVal)
            {
                char[] newPhon = new char[inVal.Length];
                int i = 0;
                foreach (char c in inVal)
                    if (c.CompareTo('0') > 0 && c.CompareTo('9') < 0)
                        newPhon[i++] = c;
                return newPhon.ToString();
            }
