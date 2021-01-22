    public static class Utils
    {
        [StructLayout(LayoutKind.Explicit)]
        struct DecimalToGuid
        {
            [FieldOffset(0)]
            public decimal Decimal;
            [FieldOffset(0)]
            public Guid Guid;
        }
        private static DecimalToGuid _converter;
        public static Guid DecimalToGuid(decimal dec)
        {
            _converter.Decimal = dec;
            return _converter.Guid;
        }
        public static decimal GuidToDecimal(Guid guid)
        {
            _converter.Guid = guid;
            return _converter.Decimal;
        }
    }
- - -
    // Prints 000e0000-0000-0000-8324-6ae7b91d0100
    Console.WriteLine(Utils.DecimalToGuid((decimal) Math.PI));
    // Prints 00000000-0000-0000-1821-000000000000
    Console.WriteLine(Utils.DecimalToGuid(8472m));
    // Prints 8472
    Console.WriteLine(Utils.GuidToDecimal(Guid.Parse("00000000-0000-0000-1821-000000000000")));
