    [Flags]
    public enum Days {
       Monday = 1,
       Tuesday = 2,
       Wednesday = 4,
       Thursday = 8,
       Friday = 16,
       Saturday = 32,
       Sunday = 64,
       MondayToFriday = 31,
       All = 127,
       None = 0
    }
    public class Weekdays {
    
       private Days _days;
    
       public Weekdays(params Days[] daysInput) {
          _days = Days.None;
          foreach (Days d in daysInput) {
             _days |= d;
          }
       }
    
       public bool Contains(Days daysMask) {
          return (_days & daysMask) == daysMask;
       }
       public bool Contains(params Days[] daysMasks) {
          Days mask = Days.None;
          foreach (Days d in daysMasks) {
             mask |= d;
          }
          return (_days & mask) == mask;
       }
    
    }
