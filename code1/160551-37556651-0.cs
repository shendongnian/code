    class Program
    {
        static void Main(string[] args)
        {
            var @decimal = 42;
            var binaryVal = ToBinary(@decimal, 2);
            var binary = "101010";
            var decimalVal = ToDecimal(binary, 2);
            Console.WriteLine("Binary value of decimal {0} is '{1}'", @decimal, binaryVal);
            Console.WriteLine("Decimal value of binary '{0}' is {1}", binary, decimalVal);
            Console.WriteLine();
            @decimal = 6;
            binaryVal = ToBinary(@decimal, 3);
            binary = "20";
            decimalVal = ToDecimal(binary, 3);
            Console.WriteLine("Base3 value of decimal {0} is '{1}'", @decimal, binaryVal);
            Console.WriteLine("Decimal value of base3 '{0}' is {1}", binary, decimalVal);
            Console.WriteLine();
            @decimal = 47;
            binaryVal = ToBinary(@decimal, 4);
            binary = "233";
            decimalVal = ToDecimal(binary, 4);
            Console.WriteLine("Base4 value of decimal {0} is '{1}'", @decimal, binaryVal);
            Console.WriteLine("Decimal value of base4 '{0}' is {1}", binary, decimalVal);
            Console.WriteLine();
            @decimal = 99;
            binaryVal = ToBinary(@decimal, 5);
            binary = "344";
            decimalVal = ToDecimal(binary, 5);
            Console.WriteLine("Base5 value of decimal {0} is '{1}'", @decimal, binaryVal);
            Console.WriteLine("Decimal value of base5 '{0}' is {1}", binary, decimalVal);
            Console.WriteLine();
            Console.WriteLine("And so forth.. excluding after base 10 (decimal) though :)");
            Console.WriteLine();
            @decimal = 16;
            binaryVal = ToBinary(@decimal, 11);
            binary = "b";
            decimalVal = ToDecimal(binary, 11);
            Console.WriteLine("Hexidecimal value of decimal {0} is '{1}'", @decimal, binaryVal);
            Console.WriteLine("Decimal value of Hexidecimal '{0}' is {1}", binary, decimalVal);
            Console.WriteLine();
            Console.WriteLine("Uh oh.. this aint right :( ... but let's cheat :P");
            Console.WriteLine();
            @decimal = 11;
            binaryVal = Convert.ToString(@decimal, 16);
            binary = "b";
            decimalVal = Convert.ToInt32(binary, 16);
            Console.WriteLine("Hexidecimal value of decimal {0} is '{1}'", @decimal, binaryVal);
            Console.WriteLine("Decimal value of Hexidecimal '{0}' is {1}", binary, decimalVal);
            Console.ReadLine();
        }
        static string ToBinary(decimal number, int @base)
        {
            var round = 0;
            var reverseBinary = string.Empty;
            
            while (number > 0)
            {
                var remainder = number % @base;
                reverseBinary += remainder;
                round = (int)(number / @base);
                number = round;
            }
            var binaryArray = reverseBinary.ToCharArray();
            Array.Reverse(binaryArray);
            var binary = new string(binaryArray);
            return binary;
        }
        static double ToDecimal(string binary, int @base)
        {
            var val = 0d;
            if (!binary.All(char.IsNumber))
                return 0d;
            for (int i = 0; i < binary.Length; i++)
            {
                var @char = Convert.ToDouble(binary[i].ToString());
                var pow = (binary.Length - 1) - i;
                val += Math.Pow(@base, pow) * @char;
            }
            return val;
        }
    }
