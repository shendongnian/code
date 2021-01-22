    public class Sending: IComparable<Sending>
    {
      // ...
      public int CompareTo(Sending other)
      {
        return other == null ? 1 : DateSent.CompareTo(other.DateSend);  
      }
    }
