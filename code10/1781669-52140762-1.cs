      static void Main(string[] args) {
        while (true) {
          int Num01;
          int Num02;
          Console.WriteLine("What do you want to do?");
          string Answer = Console.ReadLine().Trim();  
          if (string.Equals(Answer, "Quit", StringComparison.OrdinalIgnoreCase)) {
            break;
          }
          else if (string.Equals(Answer, "Division", StringComparison.OrdinalIgnoreCase)) {
            Num1 = ReadValue("Write number");
            Num2 = ReadValue("Divided by?", x => x != 0, "Sorry you can't divide by 0");
            Console.WriteLine($"{Num1} / {Num2} = {Num1 / Num2}");
          }           
          else {
            Console.WriteLine("Sorry, it's an incorrect option");
          } 
       }
     }
