    static void Main(string[] args)
    {
        Console.WriteLine("Please enter the current day of the week.");
        string currentday = Console.ReadLine();
        days day;
        if (Enum.TryParse<days>(currentday, out day))
        {
            Console.WriteLine("Good job.  Today is " + currentday);
        }
        else
        {
           Console.WriteLine("Not a valid day");
        }
        Console.ReadLine();
    }
