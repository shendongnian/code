    public class MyBase
    {
       public int X { get; set; }
       public int Y { get; set; }
       public int Z { get; set; }
       public void MethodA()
       {
             
       }
       public void MethodB()
       {
    
       }
       public void MethodC()
       {
    
       }
    }
    
    public class ClassA : MyBase
    {
       public ClassA()
       {
             
       }
       public ClassA(int x, int y, int z)
       {
          X = x;
          Y = y;
          Z = z;
       }
    }
    public class ClassB : MyBase
    {
    
    }
