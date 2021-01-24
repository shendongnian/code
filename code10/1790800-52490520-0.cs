    static void Main(string[] args)
    {
        Console.WriteLine("imput url ");
        string stringImput = Console.ReadLine();
        string BinaryString = (ToBinaryString(Encoding.UTF8, stringImput));
        Console.WriteLine(BinaryString);
        ToSoundString(BinaryString);
        Console.ReadLine();
    }
    static string ToBinaryString(Encoding encoding, string text)
    {
        return string.Join("", encoding.GetBytes(text).Select(n => Convert.ToString(n, 2).PadLeft(8, '0')));
    }
    public static void ToSoundString(string message)
    {
        const int zeroFreq = 500;
        const int oneFreq = 800;
        foreach (char c in message)
        {
            switch (c)
            {
                case '0':
                    Console.Beep(zeroFreq, 100);
                    break;
                case '1':
                    Console.Beep(oneFreq, 100);
                    break;
            }
        }
    }
