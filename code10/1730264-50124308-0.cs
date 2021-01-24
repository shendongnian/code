    try
    {
        Console.WriteLine("Hello!  A week has 7 days!  What day of this week is it?");
        var dayEntered = Console.ReadLine();
        int dayInt;
        bool success = int.TryParse(dayEntered, dayInt);
        if(!success || dayInt < (int)EDay.Monday || dayInt > (int)EDay.Sunday)
        {
            //either throw a new exception to go into your catch block or just have logic here.
        }
        EDay pickDay = (EDay)dayInt;
        Console.WriteLine("The day you picked was {0}", pickDay - 1);
        Console.ReadLine();
    }
    catch (Exception)
    {
        Console.WriteLine("Please enter an actual numerical day of the week.");
        Console.ReadLine();
    }
