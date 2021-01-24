    Console.Write("How many children do you have: ");
    while (!double.TryParse(Console.ReadLine(), out k) || k < 0)
    {
        if (k < 0)
        {
            Console.WriteLine("You must enter a positive number.");
        }
        else 
        {
            Console.WriteLine("You must enter a valid number.");
        }
    }
