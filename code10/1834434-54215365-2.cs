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
                    Name = Console.ReadLine();
                    Console.WriteLine("Enter Your Age");
                    int.TryParse(Console.ReadLine(), out Age);
                    Console.WriteLine("Hello User: "+Name+" you are: "+ Age+" Years old");
                    Console.ReadKey();
                }
            } 
        }
