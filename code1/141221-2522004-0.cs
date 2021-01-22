    public class FrobAndState
    {
      public Frob Frobber { get; set;}
      public bool State { get; set; }
    }
    public class Frob
    {
      public List<int> Values { get; private set; }
      public Frob(int[] values)
      {
        Values = new List<int>(values);
      }
    }
