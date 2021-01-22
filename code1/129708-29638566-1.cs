    class Person : IBorn
    {
      public DateTime Birth {get; set;}
    }
    interface IBorn
    {
      DateTime Birth {get; set;} 
    }
    interface IDateTimeFactory
    {
      DateTime Now();     
    }
    class DefaultDateTimeFactory : IDateTimeFactory
    {
      public DateTime Now()
      {
        return DateTime.Now;
      }
    }
    public static class IBornExtensions
    {
      public TimeSpan AgeFromNow(this IBorn birthed, IDateTimeFactory dtf)
      {
        return dtf.Now() - birthed.Birth;
      }
      public TimeSpan AgeFrom(this IBorn birthed, DateTime from)
      {
        return from - birthed.Birth;
      }
    }
    class Computer
    {
      public void checkAge(IBorn birthed)        
      {
        var age = birthed.Age((new DefaultDateTimeFactory()).Now());
      }
    }
