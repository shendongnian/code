    public interface IObjectWithX
    {
      void X();
    }
    
    public class MyObjectWithX : IObjectWithX
    {
      public void X()
      {
        // do something
      }
    }
    
    public class ActionClass
    {
      public static void DoWork(IObjectWithX handlerObject)
      {
        // do work
        handlerObject.X();
      }
    }
    
    public static void Main()
    {
      var obj = new MyObjectWithX()
      ActionClass.DoWork(obj);
    }
