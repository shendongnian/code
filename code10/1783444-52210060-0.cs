    for (int x = 1; x <= 15; x++)
    {
        switch (x % 15)
        {
            // Evenly divisible by 15
            case 0:
                Console.WriteLine("FizzBuzz");
                break;
            // Evenly divisible by 3
            case 3:
            case 6:
            case 9:
            case 12:
                Console.WriteLine("Fizz");
                break;
            // Evenly divisible by 5
            case 5:
            case 10:
                Console.WriteLine("Buzz");
                break;
            // Everything else
            default:
                Console.WriteLine(i);
                break;
        }
    }
