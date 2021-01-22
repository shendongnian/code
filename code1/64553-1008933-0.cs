    using System;
    using System.Collections.Generic;
    using System.Text;
    
    namespace FloatVsDecimal
    {
        class Program
        {
            static void Main(string[] args) 
            {
                Decimal _decimal = 1.0m;
                float _float = 1.0f;
                for (int _i = 0; _i < 5; _i++)
                {
                    Console.WriteLine("float: {0}, decimal: {1}", 
                                    _float.ToString("e10"), 
                                    _decimal.ToString("e10"));
                    _decimal += 0.1m;
                    _float += 0.1f;
                }
                Console.ReadKey();
            }
        }
    }
