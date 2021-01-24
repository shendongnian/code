    using System;
    namespace Demo
    {
        class Program
        {
            static void Main()
            {
                ulong value = 0;
                value = SetBits(value, 8, 0b111111111111, 6);
                // Expected result = 11111100000000
                Console.WriteLine(Convert.ToString((long)value, 2)); 
                value = SetBits(value, 17, 0xFFFF, 7);
                // Expected result = 111111100011111100000000
                Console.WriteLine(Convert.ToString((long)value, 2));
                value = SetBits(value, 19, 0, 2);
                // Expected result = 111001100011111100000000
                Console.WriteLine(Convert.ToString((long)value, 2));
            }
            public static ulong SetBits(ulong value, int bitOffsetInOutput, int inputBits, int inputBitCount)
            {
                ulong outputMask = (1ul << bitOffsetInOutput+inputBitCount) - (1ul << bitOffsetInOutput);
                ulong inputMask  = (1ul << inputBitCount) - 1ul;
                return (value & ~outputMask) | (((ulong)inputBits & inputMask) << bitOffsetInOutput);
            }
        }
    }
