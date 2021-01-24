    void GetYearInput(ref int year)
    {
        while (lastYear >= 0 && lastYear <= 30)
        {
            Console.WriteLine("Enter number contestants last year >> ");
            lastYear = int.Parse(Console.ReadLine());
            lastYear++;
        }
    }
