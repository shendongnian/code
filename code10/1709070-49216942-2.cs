    int i = 0; //No reason to use float here, int is just fine
    while (i <= 100)
    {
        bool divisibleBy3 = i % 3 == 0;
        bool divisibleBy5 = i % 5 == 0;
    
        if (divisibleBy3 && divisibleBy5)
            Console.WriteLine("FizzBuzz");
        else if (divisibleBy3)
            Console.WriteLine("Fizz");
        else if (divisibleBy5)
            Console.WriteLine("Buzz");
    
        i += 1;
    }
    Console.WriteLine("Done");
    Console.ReadKey(true);
