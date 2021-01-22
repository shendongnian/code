    enum EnumA { A1, A2, A1234 }
    enum EnumB { B00, B01, B02, B04 }
    class Program
    {
        static void Main(string[] args)
        {
            EnumA a = ((EnumA[])Enum.GetValues(typeof(EnumA)))[0];
            Console.WriteLine(a);
            EnumB boa = (EnumB)3;
            Console.WriteLine(boa);
        }
    }
