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
                    int Age;
                    Console.WriteLine("Enter Your Name");
                    var name = Console.ReadLine();
                    Console.WriteLine("Enter Your Age");
                    int.TryParse(Console.ReadLine(), out Age);
                    Console.WriteLine("Hello User: "+Name+" you are: "+ Age+" Years old");
                    Console.ReadKey();
                }
            } 
        }
