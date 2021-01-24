    string age1 = Console.ReadLine();
    try
    {
        student.Age = int.Parse(age1);
        if (student.Age < 0 || student.Age > 100)
            Console.WriteLine("Please enter a valid age!");
        else
            Console.WriteLine($"Age: {student.Age} ");
    }
    catch (FormatException)
    {
        Console.WriteLine("Invalid number entered.");
    }
