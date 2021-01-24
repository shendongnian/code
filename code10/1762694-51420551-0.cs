      using System;    
      using System.Collections.Generic;    
      using System.Linq;    
      using System.Text;    
      using System.Threading.Tasks;
      namespace cSharp_Assignment
      {    
      class Program
      {
        static void Main(string[] args)
        {    
            Console.WriteLine("Type A to go to Fahrenheit Converter");
            Console.WriteLine("Type B to go to Coin Change");
            Console.WriteLine("Type C to go to Number Pattern");
            string menuChoice = Console.ReadLine().ToUpper();
            switch (menuChoice)
            {
                case "A":
                    fahrenheitConverter();
                    break;
                case "B":
                    break;
                case "C":
                    break;
                case "D":
                    break;
            }
        }
        public static void fahrenheitConverter()
        {
            int Fahrenheit = 0;
            Console.WriteLine("Insert a temperature in Fahrenheit");
            Console.ReadLine();
            int Celcius = ((Fahrenheit - 32) * (5 / 9));
            Console.WriteLine("Celcius is: " + Celcius); 
            
            Main(null); // Just call the main method here. This should work. But not recomended   
        }
    }
} 
