    using System;
    using System.Collections.Generic;
    using System.Globalization;
    namespace ConsoleApplication
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.Write("Input bytes: ");
                String input = Console.ReadLine();
                String[] valueArray = input.Split(new string[] { "\\x" }, StringSplitOptions.RemoveEmptyEntries);
                List<byte> byteArray = new List<byte>();
                for (int i = 0; i < valueArray.Length; i++) {
                    int ret = -1;
                    string hex = valueArray[i];
                    if (hex.StartsWith("0x"))
                        hex = hex.Substring(2, hex.Length - 2);
                    if (!Int32.TryParse(hex, NumberStyles.HexNumber, null, out ret) || ret < 0 || ret > 0xff) {
                        Console.WriteLine("{0} is not valid hex", valueArray[i]);
                        return;
                    }
                    byteArray.Add((byte)ret);
                }
            }
        }
    }
