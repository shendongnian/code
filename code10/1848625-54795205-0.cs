    class MainClass
        {    
        static void Main(string[] args)
            {    
                Console.Write("Enter your name : ");
                string Name = Console.ReadLine();
                Console.WriteLine("Hey there, " +Name );
                Console.ReadLine();
                Console.Write("How old are you : ");
                string Age = Console.ReadLine();
                Console.WriteLine(" Hello " + Name + " you are " + Age + "!");
                Console.Write("bank card account number :");
                string AccountNumber = Console.ReadLine();
                Console.WriteLine("Thank you! to confirm, is your account number : " + AccountNumber);
                bool confirmed = Console.ReadLine().ToLower() == "yes";
    
                if (confirmed) 
                {
                    Console.WriteLine("Thank you, we can confirm your details are correct");
                }
    
                else 
                {
                    Console.WriteLine("re enter your details : ");
                }
    
                Console.ReadLine();
            }
        }
