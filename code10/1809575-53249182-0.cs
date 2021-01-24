    int s = 0;
    for (int i = 1; i <= b; i++)
    {
        Console.WriteLine("Enter " + i + " Number");
        c = int.Parse(Console.ReadLine());
        s=s-c;//Or simpler s -= c;
    }
