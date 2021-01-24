    public class DateRange
    {
      public DateTime StartDate { get; set; }
      public DateTime EndDate { get; set; }
    }
    
    public DateRange GetStaticDateRange()
    {
      //It seems counterproductive to add all 4 dates here, 
      //given that these are all one after the other
      return new DateRange
      { 
        StartDate = new DateTime(2018, 7, 10),
        EndDate = new DateTime(2018, 7, 13) 
      };
      //Obviously this can be modified as needed to return whatever combination of 
      //start-end dates you want, but this method will only ever return ONE range
      //However, this method could just as well accept parameters and / or access other resources
    }
    
    public bool IsInDateRange(DateTime dateToCheck, DateRange targetRange)
    {
      //An argument can be made to use non-encompassing comparisons for both checks
      //depending on your requirements
      return dateToCheck >= targetRange.StartDate && dateToCheck <= targetRange.EndDate;
    }
