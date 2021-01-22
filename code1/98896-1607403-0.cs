    public void Init(string name, MyManager.Types type)
    {
       MyObject.Types t = type.ToMyObjectType();
    }
    
    internal static class Extensions
    {
       public static MyObject.Types ToMyObjectType(this MyManager.Types t)
       {
          //do mapping
       }
    }
