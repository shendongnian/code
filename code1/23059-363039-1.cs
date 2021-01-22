    public class Factory  
    {
      public static T Create<T>() where T : ParentClass
      {
        T child = new T("hi")
      }
    }
