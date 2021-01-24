    do
    {
        Console.Write("What is your total income : ");
        incomeOK = double.TryParse(Console.ReadLine(), out i);
        if (!incomeOK) 
        {
            Console.WriteLine("Enter your income as a whole-dollar numeric figure.");
            continue;
        }
        if (i < 0)
        {
            Console.WriteLine("Your income cannot be negative.");
            incomeOK = false; // You need to manually set this to false to indicate it is not ok for it to loop.
        }
    } while (!incomeOk)
    do
    {
        Console.Write("How many children do you have: ");
        kidOK = double.TryParse(Console.ReadLine(), out k);
        if (!kidOK)
        {
            Console.WriteLine("You must enter a valid number.");
            continue;
        }
        
        if(k < 0)
        {
            Console.WriteLine("You must enter a positive number.");
            kidOK = false; // Same deal as before
            continue;
        }
        /// ... Your calculations
    } while (!kidOK);
