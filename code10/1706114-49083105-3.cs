    double i;
    double k;
    Console.Write("What is your total income : ");
    while (!double.TryParse(Console.ReadLine(), out i) || i < 0)
    {
        if (i < 0)
        {
            Console.WriteLine("Your income cannot be negative.");
        }
        else 
        {
            Console.WriteLine("Enter your income as a whole-dollar numeric figure.");
        }
    }
     
