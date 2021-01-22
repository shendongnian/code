    static void Main(string[] args)
    {
        foreach (var item in Base26Sequence().TakeWhile(x => x != "zzz"))
            Console.WriteLine(item);
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
