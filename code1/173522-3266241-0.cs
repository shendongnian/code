    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication2
    {
        class ProcessCaller
        {
            static void Main()
            {
                MyDerived md1 = new MyDerived(1);
                object o = new System.Text.StringBuilder();//This will implicitly instantiate the classes in the inheritance hierarchy:  object, then stringbuilder
            }
        }
    
    public class MyBase
    {
       int num;
    
       public MyBase() 
       {
          Console.WriteLine("in MyBase()");
       }
    
       public MyBase(int i )
       {
          num = i;
          Console.WriteLine("in MyBase(int i)");
       }
    
       public virtual int GetNum()
       {
          return num;
       }
    }
    
    public class MyDerived: MyBase
    {
       //set private constructor.  base(i) here makes no sense cause you have no params
       private MyDerived()
       {
           
       }
    
        // Without specifying base(i), this constructor would call MyBase.MyBase()
       public MyDerived(int i) : base(i)
       {
       }
       public override int GetNum()
       {
           return base.GetNum();//here we use base within an instance method to call the base class implementation.  
       }
    }
    
    }
