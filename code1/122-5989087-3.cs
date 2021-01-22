    // ----------------------------------------------------------------------
    public void CalculateAgeSamples()
    {
      PrintAge( new DateTime( 2000, 02, 29 ), new DateTime( 2009, 02, 28 ) );
      // > Birthdate=29.02.2000, Age at 28.02.2009 is 8 years
      PrintAge( new DateTime( 2000, 02, 29 ), new DateTime( 2012, 02, 28 ) );
      // > Birthdate=29.02.2000, Age at 28.02.2012 is 11 years
    } // CalculateAgeSamples
    
    // ----------------------------------------------------------------------
    public void PrintAge( DateTime birthDate, DateTime moment )
    {
      Console.WriteLine( "Birthdate={0:d}, Age at {1:d} is {2} years", birthDate, moment, YearDiff( birthDate, moment ) );
    } // PrintAge
