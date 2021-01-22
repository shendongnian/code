    static void Main(string[] args)
    {
        Console.WriteLine(GetNextBase26("a"));
        Console.WriteLine(GetNextBase26("bnc"));
    }
    private static string GetNextBase26(string a)
    {
        return Base26Sequence().SkipWhile(x => x != a).Skip(1).First();
    }
    private static IEnumerable<string> Base26Sequence()
    {
        long i = 0L;
        while (true)
            yield return Base26Encode(i++);
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
