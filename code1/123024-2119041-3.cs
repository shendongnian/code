    double total = 0; //the total
    
    for (int i = 1; i <= 7; i++)
    {
        double c = i / fact(i);
        total += c; // build up the value each time
        Console.WriteLine("Factorial is : " + c);
        Console.ReadLine();
        Console.WriteLine("By Adding.. will give " + total);
    
    }
