    public static bool HexInCardUID(string test)
            {
                if (test.Trim().Length != 14)
                    return false;
                for (int i = 0; i < test.Length; i++)
                    if (!Uri.IsHexDigit(Convert.ToChar(test.Substring(i, 1))))
                        return false;
                return true;
            }**strong text**
