    static void Main(string[] args)
    {
        for (int i = 0; i < 10000000; i++)
        {
            Console.WriteLine(Base26Encode(i));
        }
    }
    private static char[] base26Chars = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
    public static string Base26Encode(Int64 value)
    {
        string returnValue = null;
        do
        {
            returnValue = base26Chars[value % 26] + returnValue;
            value /= 26;
        } while (value-- != 0);
        return returnValue;
    }
