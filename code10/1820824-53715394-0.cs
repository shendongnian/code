    int sum = 0, counter = 0, number = 0, lessCounter = 0;
    
    while (counter < 5)
    {
        number = Convert.ToInt16(Console.ReadLine());
        sum += number;
        if (number < 50)
            lessCounter++;
        counter++;
    }
    if (lessCounter <= 1)
        Console.WriteLine(sum + "\nPassed");
    else
        Console.WriteLine(sum + "\nSTOP");
