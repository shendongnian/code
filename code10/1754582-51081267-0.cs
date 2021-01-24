    using System;
    using System.Globalization;
    using System.Numerics;
    
    class Program
    {
        static void Main()
        {
            var number = BigInteger.Parse("728faf34b64cd55c8d1d500268026ffb", NumberStyles.HexNumber);
            Console.WriteLine(number);
        }
    }
