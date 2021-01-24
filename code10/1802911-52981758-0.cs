    double doubleValue = double.Parse(Console.ReadLine());
    int wholeNumber = 0;
    if ((doubleValue - Math.Floor(doubleValue) > 0))
    {
        wholeNumber = int.Parse(Math.Ceiling(doubleValue).ToString());
    }
    else
    {
        wholeNumber = int.Parse((doubleValue + 1).ToString());
    }
