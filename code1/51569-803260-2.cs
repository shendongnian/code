    private const float THREE_FIFTHS = 3f / 5f;
    private const int ONE_MILLION = 1000000;
    public static void Main(string[] args)
    {
        Console.WriteLine("Three Fifths: {0}", THREE_FIFTHS.ToString("F10"));
        float asSingle = 0f;
        double asDouble = 0d;
        decimal asDecimal = 0M;
        for (int i = 0; i < ONE_MILLION; i++)
        {
            asSingle += THREE_FIFTHS;
            asDouble += THREE_FIFTHS;
            asDecimal += (decimal) THREE_FIFTHS;
        }
        Console.WriteLine("Six Hundred Thousand: {0:F10}", THREE_FIFTHS * ONE_MILLION);
        Console.WriteLine("Single: {0}", asSingle.ToString("F10"));
        Console.WriteLine("Double: {0}", asDouble.ToString("F10"));
        Console.WriteLine("Decimal: {0}", asDecimal.ToString("F10"));
        Console.ReadLine();
    }
