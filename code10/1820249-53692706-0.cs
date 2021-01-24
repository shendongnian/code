     Console.WriteLine("Enter first input");
     double input1 = double.Parse(Console.ReadLine());
     Console.WriteLine("Enter second input");
     double input2 = double.Parse(Console.ReadLine());
     Calculator myCalculator = new Calculator();
     double result = myCalculator.Calculation(input1, input2);
     Console.WriteLine("result = " + result);
     
