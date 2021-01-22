    try{
        return (22 / 0); // Cant devise by 0
    }catch (System.DivideByZeroException ZeroEx) //Catch type of exception and assign to variable
    {
       Console.WriteLine("Division by zero attempted!");
       Console.WriteLine("Are you sure you wish to continue");
       string answer = Console.Read();
    }
