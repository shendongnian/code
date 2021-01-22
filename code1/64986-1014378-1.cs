    public class A
    {
       public virtual void One();
       public void Two();
    }
    
    public class B : A
    {
       public override void One();
       public new void Two();
    }
    
    B b = new B();
    A a = b as A;
    
    a.One(); // Calls implementation in B
    a.Two(); // Calls implementation in A
    b.One(); // Calls implementation in B
    b.Two(); // Calls implementation in B
