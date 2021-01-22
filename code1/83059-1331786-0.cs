    public abstract class AAA
    {
      protected abstract string ToStringSpecific();
      protected string ToString()
      {
        // Base Stuff
        ...
        // Use this.ToStringSpecific();
      }
    }
    
    public class BBB : AAA
    {
      protected override string ToStringSpecific()
      {
        // Specific Stuff
      }
    }
