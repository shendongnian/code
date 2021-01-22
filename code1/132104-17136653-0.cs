    //No access to the source of the following classes
    public class Base
    {
         public virtual void method1(){ Console.WriteLine("In Base");}
    }
    public class Derived : Base
    {
         public override void method1(){ Console.WriteLine("In Derived");}
         public void method2(){ Console.WriteLine("Some important method in Derived");}
    }
    //Here should go your classes
    //First do your own derived class
    public class MyDerived : Base
    {         
    }
    //Then derive from the derived class 
    //and call the bass class implementation via your derived class
    public class specialDerived : Derived
    {
         public override void method1()
         { 
              MyDerived md = new MyDerived();
              //This is actually the base.base class implementation
              MyDerived.method1();  
         }         
    }
