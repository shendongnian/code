        class Program
        {
            static void Main(string[] args)
            {
                string name;
                int age;
    
                AskPersonalData( out name, out age );
                Console.WriteLine( "Hello User" + name + "you are" + age + " Years old" );
            }
    
            static void AskPersonalData(out string name, out int age)
            {
                Console.Write( "Enter Your Name: " );
                name = Console.ReadLine();
    
                Console.Write( "Enter Your Age: " );
                age = Convert.ToInt32( Console.ReadLine() );
            }
        } 
