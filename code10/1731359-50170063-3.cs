    static void Main()
    {
        int[] marks = new int[5];
    
        int a = 0;
    
        Console.WriteLine("Enter 5 elements:");
    
        while (a < 5)
        {
            if (int.TryParse(Console.ReadLine(), out marks[a]))
                a++;
            else
                Console.WriteLine("You didn't enter a number! Please enter again!");
        }
    
        double average = marks.Average();
    
        if (average > 0)
            Console.WriteLine("Positive");
        else
            Console.WriteLine("Negative");
    }
