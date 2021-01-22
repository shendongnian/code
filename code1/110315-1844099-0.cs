    public static void Main()
    {
     A o = new A();
     Console.WriteLine(o.f());
    }
    
    class C
    {
     public virtual string f()
     {
      return "C";
     }
    }
    
    class B : C
    {
     public virtual string f()
     {
      return "B";
     }
    }
    
    class A : B
    {
     public virtual string f()
     {
         C c = this;
         return c.f();
     }
    }
