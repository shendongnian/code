       public static int CalculateAge(DateTime BirthDate)
       {
            int YearsPassed = DateTime.Now.Year - BirthDate.Year;
            // Are we before the birth date this year? If so subtract one year from the mix
            if (DateTime.Now.Month < BirthDate.Month || (DateTime.Now.Month == BirthDate.Month && DateTime.Now.Day < BirthDate.Day))
            {
                YearsPassed--;
            }
            return YearsPassed;
      }
