    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication51
    {
        class Program
        {
            static void Main(string[] args)
            {
                string pattern = "[A-Z].*";
                string input =
                    "თანხის შეტანა ბარათი მარჯანიშვილის ფილიალი VISA CLASSIC GE****************0082 GEL\n" +
                    "თანხის შეტანა შემნახველი მარჯანიშვილის ფილიალი ჩემი სეიფი GE****************0018 GEL@\n" +
                    "თანხის შეტანა ბარათი ცენტრალური ფილიალი MC STANDARD GE****************0006 USD კურსი - 2.5@\n";
                StringReader reader = new StringReader(input);
                string line = "";
                while((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(Regex.Match(line, pattern).Value);
                }
                Console.ReadLine();
            }
        }
     
        
    }
