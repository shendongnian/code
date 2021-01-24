    public static string DisplayEmptyCircles(int count)
    {
        return new string(Convert.ToChar(9675), count);
    }
    Console.WriteLine("Level 1 : " + DisplayEmptyCircles(firstLevel.Count));
