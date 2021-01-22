    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace MyTokenizer
    {
        class Program
        {
            enum TokenTypes { SimpleToken, UberToken }
            class Token { public TokenTypes TokenType = TokenTypes.SimpleToken;    }
            class MyUberToken : Token { public MyUberToken() { TokenType = TokenTypes.UberToken; } }
            static void Main(string[] args)
            {
                List<object> objects = new List<object>(new object[] { "A", Guid.NewGuid(), "C", new MyUberToken(), "D", new MyUberToken(), "E", new MyUberToken() });
                var splitOn = TokenTypes.UberToken;
                foreach (var list in objects.Split(x => x is Token && ((Token)x).TokenType == splitOn))
                {
                    foreach (var item in list)
                    {
                        Console.WriteLine(item);
                    }
                    Console.WriteLine("==============");
                }
                Console.ReadKey();
            }
        }
    }
