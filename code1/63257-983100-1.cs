    public interface IDoesStuff<T>
    {
      T DoStuff();
    }
    
    public class A : IDoesStuff<int>
    {
      public int DoStuff()
      {  return 0; }
    }
    
    public class B : IDoesStuff<string>
    {
      public string DoStuff()
      { return ""; }
    }
    public class MyMagicContainer<T, U> where T : IDoesStuff<U>
    {
      U GetStuff(T theObject)
      {
        return theObject.DoStuff();
      }
    }
