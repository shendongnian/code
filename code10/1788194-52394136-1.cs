    public DateTime GetOldestBirthDate()
    {
        DateTime birthDate = DateTime.Now;
    
        foreach (var item in List<Student>)
        {
             if (birthDate < item.birthDate)             
                    birthDate = item.birthDate;
        }
        return birthDate;
    }
