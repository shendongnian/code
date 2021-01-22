    public static string HowOld(DateTime birthday, DateTime now)
    {
        if (now < birthday)
            throw new ArgumentOutOfRangeException("birthday must be less than now.");
            
        TimeSpan diff = now - birthday;
        int diffDays = (int)diff.TotalDays;
        if (diffDays > 7)//year, month and week
        {
            int age = now.Year - birthday.Year;
            if (birthday > now.AddYears(-age))
                age--;
            if (age > 0)
            {
                return age + (age > 1 ? " years" : " year");
            }
            else
            {// month and week
                DateTime d = birthday;
                int diffMonth = 1;
                while (d.AddMonths(diffMonth) <= now)
                {
                    diffMonth++;
                }
                age = diffMonth-1;
                if (age == 1 && d.Day > now.Day)
                    age--;
                if (age > 0)
                {
                    return age + (age > 1 ? " months" : " month");
                }
                else
                {
                    age = diffDays / 7;
                    return age + (age > 1 ? " weeks" : " week");
                }
            }
        }
        else if (diffDays > 0)
        {
            int age = diffDays;
            return age + (age > 1 ? " days" : " day");
        }
        else
        {
            int age = diffDays;
            return "just born";
        }
    }
