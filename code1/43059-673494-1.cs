    public int getAgeInYears {
      TimeSpan tsAge = DateTime.Now.Subtract(dtDOB);
      
      return new DateTime(tsAge.Ticks).Year - 1;
    }
