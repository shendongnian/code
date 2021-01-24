    static void Main(string[] args)
    {
       Console.WriteLine("Enter first number");
    
       // this is not quite DRY, however it is easy to read
       if (!EnterNumber(out var firstNum))
       {
          Console.WriteLine("Kdot");
          Console.ReadKey();
          return;
       }
    
       Console.WriteLine("Enter second number");
       if (!EnterNumber(out var secondNum))
       {
          Console.WriteLine("Kdot");
          Console.ReadKey();
          return;
       }
    
       Console.WriteLine("Enter third number");
       if (!EnterNumber(out var thirddNum))
       {
          Console.WriteLine("Kdot");
          Console.ReadKey();
          return;
       }
    
       Console.WriteLine($"Addition = {firstNum + secondNum + thirddNum}");
       Console.WriteLine($"Subtraction = {firstNum - secondNum - thirddNum}");
       Console.WriteLine($"Multiplication = {firstNum * secondNum * thirddNum}");
       // you need to cast int to double otherwise you will get unexpected results
       Console.WriteLine($"Division = {(double)firstNum /(double) secondNum / (double)thirddNum}");
       Console.WriteLine($"Modulo = {firstNum % secondNum % thirddNum}");
       Console.ReadKey();
    }
