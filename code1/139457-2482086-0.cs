    public class DateCalculator
    {
      public DateTime GetNextExpirationDate() {  // call to GetBaseLineDate() to determine result }
      virtual protected GetBaseLineDate() {  return DateTime.Today; }
    }
    
    // in your test assembly
    public class DateCalcWithSettableBaseLine : DateCalculator
    {
      public DateTime BaseLine { get; set;}
      override protected GetBaseLineDate()
      {    return this.BaseLine;  }
    }
