    public static int GetAge(DateTime birthDate)
    {
        DateTime n = DateTime.Now; // To avoid a race condition around midnight
        int age = n.Year - birthDate.Year;
        if (n.Month < birthDate.Month || (n.Month == birthDate.Month && n.Day < birthDate.Day))
            age--;
        return age;
    }
