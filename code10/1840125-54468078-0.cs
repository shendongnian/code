    public static void Main(string[] args)
    {
        for (int i = 0; i < 100; i++)
        {
            var birthDate = CalculateDob(70, 105);
            var now = DateTime.Now;
            int age = now.Year - birthDate.Year;
            if (now.Month < birthDate.Month || (now.Month == birthDate.Month && now.Day < birthDate.Day))
            {
                age--;
            }
            Console.WriteLine(age);                
        }
    }
    //Construct this as static so that we don't keep seeding the rand    
    private static readonly Random _random = new Random();
    static DateTime CalculateDob(int youngestAge, int oldestAge)
    {
    
                
        int age = 0;
        age = _random.Next(70, 105);
        var today = DateTime.Now;
        var year = today.Year - age;
        var month = _random.Next(1, 12);
    
        //Age might less than youngest age,
        //if born at/after current month, edge condition
        if (month >= today.Month)
        {
    
            month = today.Month - 1;
            if (month < 1)
            {
                year--;
                month = 12;
            }
        }
    
        var day = _random.Next(1, DateTime.DaysInMonth(year, month));
        return new DateTime(year, month, day);
    }
