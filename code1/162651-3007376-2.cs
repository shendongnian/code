    string base36Characters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    string toBase36(int x, int digits)
    {
        char[] result = new char[digits];
        for (int i = digits - 1; i >= 0; --i)
        {
            result[i] = base36Characters[x % 36];
            x /= 36;
        }
        return new string(result);
    }
    IEnumerable<string> base36Counter()
    {
        for (int n = 0; n < 36 * 36 * 36 * 36; ++n)
        {
            yield return toBase36(n, 4);
        }
    }
    void Run()
    {
        foreach (string s in base36Counter())
            Console.WriteLine(s);
    }
