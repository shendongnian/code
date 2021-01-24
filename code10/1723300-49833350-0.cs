    namespace ConsoleApp1
    {
      class Program
      {
        static void Main()
        {
          while(true) //loop forever
          {
            Console.WriteLine("do you want to (A)dd (E)dit or (X) Exit?");
            string choice = Console.ReadLine();
            if (choice == "A")
            {
              //Do add stuff here
            } 
            else if (choice == "E")
            {
              //Do edit stuff here
            } 
            else if (choice == "X")
            {
              break; //exit the loop
            }
            else
            {
              Console.WriteLine("unknown command");
            }
          }
        }
      }
    }
