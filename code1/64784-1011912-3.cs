    static void Main(string[] args)
    {
        foreach (var item in Base26Until("fgh"))
        {
            Console.WriteLine(item);
        }
    }
    private static IEnumerable<string> Base26Until(string end)
    {
        string result = null;
        long i = 0L;
        while ((result = Base26Encode(i++)) != end)
        {
            yield return result;
        }
    }
    private static char[] base26Chars = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
    private static string Base26Encode(Int64 value)
    {
        string returnValue = null;
        do
        {
            returnValue = base26Chars[value % 26] + returnValue;
            value /= 26;
        } while (value-- != 0);
        return returnValue;
    }
