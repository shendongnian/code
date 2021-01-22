    static void Main()
    {
        string string1 = "basement";
        string string2 = "**a*f**a";
        string[] result = GetCombinations(string1, string2);
        foreach (var item in result)
        {
            Console.WriteLine(item);
        }        
    }
    private static string[] GetCombinations(string string1, string string2)
    {
        var list = new List<List<char>> { new List<char>(), new List<char>() };
        var cl = new List<char>();
        List<string> result = new List<string>();
        for (int i = 0; i < string1.Length; i++)
        {
            if (string2[i] == '*')
            {
                cl.Add(string1[i]);
            }
            else
            {
                list[0].Add(string1[i]);
                list[1].Add(string2[i]);
            }
        }
        int l = list[0].Count;
        for (int i = 0; i < (Int64)Math.Pow(2.0,l); i++)
        {
            string s = ToBinary(i, l);
            string ss = "";
            int x = 0;
            int y = 0;
            for (int I = 0; I < string1.Length; I++)
            {
                if (string2[I] == '*')
                {
                    ss += cl[x].ToString();
                    x++;
                }
                else
                {
                    ss += (list[int.Parse(s[y].ToString())][y]);
                    y++;
                }
            }
            result.Add(ss);
        }
        return result.ToArray<string>();
    }
    public static string ToBinary(Int64 Decimal, int width)
    {
        Int64 BinaryHolder;
        char[] BinaryArray;
        string BinaryResult = "";
        while (Decimal > 0)
        {
            BinaryHolder = Decimal % 2;
            BinaryResult += BinaryHolder;
            Decimal = Decimal / 2;
        }
        BinaryArray = BinaryResult.ToCharArray();
        Array.Reverse(BinaryArray);
        BinaryResult = new string(BinaryArray);
        var d = width - BinaryResult.Length;
        if (d != 0) for (int i = 0; i < d; i++) BinaryResult = "0" + BinaryResult;
        return BinaryResult;
    }
