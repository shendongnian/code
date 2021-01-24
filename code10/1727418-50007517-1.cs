    using System;
    using System.Text;
    namespace CharConversion
    {
        class Program
        {
            static void Main()
            {
                string[] unicodeResponses = new string[]
                {
                    "@U00430061006e20190074002000620065002000610062006c006500200074006f002000620065002000740068006500720065",
                    "@U004f006b002000bf00bf",
                    "@U004f006b002000bf00bf",
                    "@U004f004b002000bf00bf",
                    "@U004f006b002000bf00bf",
                    "@U00d2006b",
                    "@U004f004b",
                    "@U004f006b00610079002000bf00bf0020",
                    "@U004f004b",
                    "@U004f006b00bf00bf00bffffd"
                };
                string message = "";
                foreach (string unicodeResponse in unicodeResponses)
                {
                    for (int i = 2; i < unicodeResponse.Length; i += 4)
                    {
                        message += (char)Int16.Parse(unicodeResponse.Substring(i, 4), System.Globalization.NumberStyles.HexNumber);
                    }
                }
                Console.WriteLine(message);
                Console.Read();
            }
        }
    }
