    int sum = 0;
    int count = 100;
    
    for (int i = 1; i <= count; ++i)
    {
        sum += i;
    }
    double average = sum / (double)count;
    Console.WriteLine("The sum is " + sum);
    Console.WriteLine("The average is " + average);
    Console.ReadKey();
