    using System;
    
    public class Program
    {
        public static void Main()
        {
            string toParse = "1";
    		decimal parsed;
            if (Decimal.TryParse(toParse, out parsed)) {
                Console.WriteLine("Parsed: " + parsed.ToString());
            } else {
                Console.WriteLine("Nope");
            }
        }
    }
