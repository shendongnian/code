    using System;
    using System.Linq;
    
    class Test
    {
        static void Main()
        {
            string a = "0101000000110110000010010011";
            string b = "0101XXXXXXX101100000100100XX";
            
            var equal = !(a.Zip(b, (x, y) => new { x, y })
                           .Where(z => z.x != z.y && z.x != 'X' && z.y != 'X')
                           .Any());
            
            Console.WriteLine(equal);
        }
    }
