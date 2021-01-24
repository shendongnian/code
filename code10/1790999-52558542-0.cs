    /// <summary>
    /// Used for getting DateTime.Now(), time is changeable for unit testing
    /// </summary>
    public class DateTimeProvider : IDateTimeProvider
    {
       /// <summary> 
       /// Normally this is a pass-through to DateTime.Now, but it can be 
       /// overridden with SetDateTime( .. ) for testing or debugging.
       /// </summary>
       private Func<DateTime> _now = () => DateTime.Now;
       public Func<DateTime> Now { get => _now; private set => _now = value; }
       /// <summary> 
       /// Set time to return when DateTimeProvider.Now() is called.
       /// </summary>
       public void SetDateTime(DateTime dateTimeNow)
       {
          Now = () =>  dateTimeNow;
       }
       /// <summary> 
       /// Resets DateTimeProvider.Now() to return DateTime.Now.
       /// </summary>
       public void ResetDateTime()
       {
           Now = () => DateTime.Now;
       }
    }
