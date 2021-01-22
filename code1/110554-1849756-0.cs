    public class A
    {
      public A(Type classType)
      {
        object myObject = Activator.CreateInstance(...classType...);
      }
    }
    
    public class B
    {
    ...
    }
    
    public class C
    {
      public static void main(string[] args)
      {
        A a = new A(typeof(B));
      }
}
