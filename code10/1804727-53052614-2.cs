    double result = 0;
    Console.Write("Enter First Number: ");
    double num1 = Convert.ToDouble(Console.ReadLine());
    Console.Write("Enter Second Number: ");
    double num2 = Convert.ToDouble(Console.ReadLine());
    Console.WriteLine("Enter a number from 1 to 3");
    string input = Console.ReadLine();
    switch (input) {
        case "1" : 
            result = num1 + num2;
            break;
        case "2":
            result = num1 - num2;
            break;
        case "3":
            result = num1 * num2;
            break;  
        default:
        Console.WriteLine("\n Next time follow instructions. You can only choose numbers 1 - 4");
        break;
         
    }
    Console.WriteLine("Result = " + result);
