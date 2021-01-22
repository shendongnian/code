    int i = 0;
    string number = Console.ReadLine();
    if (Int32.TryParse(number, out i))
    {
        //if (i.ToString().Length == 7) // you can try this too
        if (i > 999999 && i < 10000000)
        {
            Console.WriteLine("Have exactly 7 digits");
        }
        else
        {
            Console.WriteLine("Doesn't have exactly 7 digits");
        }
    }
    else
    {
        Console.WriteLine("Not an Int32 number");
    }
