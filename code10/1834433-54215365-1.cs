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
                Console.WriteLine("Enter Your Name");
                var name = Console.ReadLine();
                Console.WriteLine("Enter Your Age");
                var key = Console.ReadLine();
                int age =0;
                int.TryParse(key, out age);
                Console.WriteLine("Hello User"+name+"you are"+ age+" Years old");
                Console.ReadKey();
                }
            } 
        }
