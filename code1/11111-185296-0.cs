    public class MyClass
    {
         private static MyClass myClass;
    
         public static MyClass MyClass
         {
              get { return myClass ?? (myClass = new MyClass()); }
         }
    
         private MyClass()
         {
              //private constructor makes it where this class can only be created by itself
         }
    }
