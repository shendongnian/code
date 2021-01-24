    namespace Methodss
    {
        class Program
        {
            static void Main(string[] args)
            {
                SayHi();
            }
            
            static void SayHi()
            {
                String Name;
                int Age;
                Console.WriteLine("Enter Your Name");
                Name=Console.ReadLine();
                Console.WriteLine("Enter Your Age");
                Age = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Hello "+"\t" + Name + " "+"you are"+" " + Age + " "+" Years old");
                Console.ReadLine();
            }
        }
    }
