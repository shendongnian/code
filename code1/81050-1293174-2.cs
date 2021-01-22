    for (int day = 1; day <= NumberOfDays; day++)
    {
        Console.WriteLine("Day {0}", day);
        Console.WriteLine(ListTeam[0]);
        for (int idx = 0; idx < NumberOfDays; idx++)
        {
                int index = (idx + day - 1) % NumberOfDays + 1;
                if (idx % 2 == 0) Console.Write(" vs ");
                Console.Write(ListTeam[index]);
                if (idx % 2 == 0) Console.WriteLine();
        }
    }
