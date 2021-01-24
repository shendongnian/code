    // declare your variables
    var firstNumber = 0;
    var validInput = false;
    // loop until you have valid input
    while (!validInput)
    {
        // get the input
        Console.Write("\n\t\t\tPlease enter your first number: ");
        var firstNumberInput = Console.ReadLine();
        // validate it
        validInput = int.TryParse(firstNumberInput, out firstNumber);
        // if it was invalid, notify the user
        if (!validInput)
        {
            Console.WriteLine("\n\t\t\tInvalid input!");
            Console.Beep();
        }
    }
