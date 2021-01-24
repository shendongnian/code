    Console.WriteLine("enter a number with change");
    double num = double.Parse(Console.ReadLine());
    int num2 = (int)num;
    int c = 0;
    Console.WriteLine(num2);
    while (num2 != 0)
    {
        num2 /= 10;
        c++;
    }
    Console.WriteLine(c);
