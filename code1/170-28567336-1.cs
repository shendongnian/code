    public static int GetAgeByLoop(DateTime birthday)
    {
        var age = -1;
    
        for (var date = birthday; date < DateTime.Today; date = date.AddYears(1))
        {
            age++;
        }
        return age;
    }
