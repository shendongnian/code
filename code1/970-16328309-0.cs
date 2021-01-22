    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace BitFlagPlay
    {
        class Program
        {
            public enum MyColor
            {
                Yellow = 0x01,
                Green = 0x02,
                Red = 0x04,
                Blue = 0x08
            }
            static void Main(string[] args)
            {
                var myColor = MyColor.Yellow | MyColor.Blue;
                var acceptableColors = MyColor.Yellow | MyColor.Red;
    
                Console.WriteLine((myColor & MyColor.Blue) > 0);     // True
                Console.WriteLine((myColor & MyColor.Red) > 0);      // False
    
                Console.WriteLine((myColor & acceptableColors) > 0); // True
                // ... though only Yellow is shared.
                
                Console.WriteLine((myColor & MyColor.Green) > 0);    // Wait a minute... ;^D
    
                Console.Read();
            }
        }
    }
