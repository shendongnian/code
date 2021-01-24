    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Globalization;/*Add this library for ToTitleCase*/
    
    namespace String_denemeler
    {
        class Program
        {
            public static string ToTitleCase(string Text)/*And Add this for ToTitleCase*/
            {
                return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Text);
            }
            static void Main(string[] args)
            {
                string name;
                Console.Write("Name&Surname:");
                name = Console.ReadLine();
                name= ToTitleCase(name);
    
                int index = name.LastIndexOf(" ");
                Console.WriteLine(name.Substring(0, index) + name.Substring(index).ToUpper());
    
            }
        }
    }
