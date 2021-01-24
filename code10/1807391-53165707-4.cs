    while (exit != "yes")
    {
        Console.WriteLine("What is the department number that you would like to enter sales for? Enter 9 to exit");
        int departmentNo = int.Parse(Console.ReadLine());
        if (departmentNo > departments.GetUpperBound(0) || departmentNo < 0)
        {
            Console.WriteLine("Please enter a valid department number.");
            continue;
        }
        Console.WriteLine("What day would you like to enter sales for?");
        int input = int.Parse(Console.ReadLine());
        if (input > departments.GetUpperBound(1) || input < 0)
        {
            Console.WriteLine("Please enter a valid input.");
            continue;
        }
        Console.WriteLine("Enter sales");
        if (!decimal.TryParse(Console.ReadLine(), out decimal value))
        {
            Console.WriteLine("Please enter a valid sales figure.");
            continue;
        }
        departments[departmentNo, input] = value;
        Console.WriteLine("If you are finished, enter yes");
        exit = Console.ReadLine();
    }
