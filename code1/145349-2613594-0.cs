    days.Sort();
    DateTime dt = days[0].Date;
    for (int i = 0; i < days.Length; dt = dt.AddDays(1))
    {
        if (dt == days[i].Date)
        {
            Console.WriteLine("Worked: {0}", dt);
            i++;
        }
        else
        {
            Console.WriteLine("Not Worked: {0}", dt);
        }
    }
