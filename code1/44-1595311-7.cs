    public int CalculateAgeWrong1(DateTime birthDate, DateTime now)
    {
        return new DateTime(now.Subtract(birthDate).Ticks).Year - 1;
    }
    public int CalculateAgeWrong2(DateTime birthDate, DateTime now)
    {
        int age = now.Year - birthDate.Year;
        if (now < birthDate.AddYears(age))
            age--;
        return age;
    }
    public int CalculateAgeCorrect(DateTime birthDate, DateTime now)
    {
        int age = now.Year - birthDate.Year;
        if (now.Month < birthDate.Month || (now.Month == birthDate.Month && now.Day < birthDate.Day))
            age--;
        return age;
    }
