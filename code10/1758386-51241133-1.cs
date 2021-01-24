    public interface IBase
    {
      void Add(string s);
    }
    public interface IDerived : IBase
    {
    }
    public class Concrete : IDerived
    {
      public void Add(string s)
      {
      }
    }
