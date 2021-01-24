    static void Main(string[] args)
    {
        List<string> list = new List<string> { "1111", "1010", "1010", "0011" };
        string st1 = "1010";
        
        foreach (string item in list)
        {
            st1 = XorBins(st1, item);
            Console.WriteLine(st1);
        }
        Console.ReadKey();
    }
    private static string XorBins(string bin1, string bin2)
    {
        int len = Math.Max(bin1.Length, bin2.Length);
        string res = "";
        bin1 = bin1.PadLeft(len, '0');
        bin2 = bin2.PadLeft(len, '0');
        for (int i = 0; i < len; i++)
            res += bin1[i] == bin2[i] ? '0' : '1';
        return res;
    }
