    int j = 0;
    string[] weekDays = new string[7];
    DateTime days = DateTime.Now;
    while (weekDays[0] != "Sunday")
    { 
        days = days.AddDays(j++);
        weekDays[0] = string.Format("{0:dddd}", days);
        if (weekDays[0] != "Sunday")
           days = DateTime.Now;  
    }
    for (int i = 0; i < weekDays.Length; i++)
    {
        weekDays[i] = string.Format("{0:dddd}", days.AddDays(i));
        Console.WriteLine(weekDays[i]);   
    }
