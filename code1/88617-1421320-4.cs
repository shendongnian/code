    public class EqualityTest : IComparable<EqualityTest>
    {
          public int Value { get; set; }
    
          public int CompareTo(EqualityTest other)
          {
               return this.Value.CompareTo(other.Value);
          }
    }
