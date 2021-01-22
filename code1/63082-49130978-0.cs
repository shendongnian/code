     public class Program
        {
            static void Main()
            {
                Console.WriteLine("Please enter Any Number");
                object value = Console.ReadLine();
                float f;
                int i;
                if (int.TryParse(Convert.ToString( value), out i))
                    Console.WriteLine(value + " is an int");
                else if (float.TryParse(Convert.ToString(value), out f))
                    Console.WriteLine(value + " is a float");
    
    
                Console.ReadLine();
            }
        }
