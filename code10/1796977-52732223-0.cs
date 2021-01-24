    Console.WriteLine("Please enter the current day of the week.");
    string currentday = Console.ReadLine();
    if (Enum.IsDefined(typeof(days), currentday))
        Console.WriteLine("Good job.  Today is " + currentday);
    else
        Console.WriteLine("Not a valid day");
    Console.ReadLine();
