    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace CovarianceContravarianceDemo
    {
        //base class
        class A
        {
    
        }
    
        //derived class
        class B : A
        {
    
        }
        class Program
        {
            static A Method1(A a)
            {
                Console.WriteLine("Method1");
                return new A();
            }
    
            static A Method2(B b)
            {
                Console.WriteLine("Method2");
                return new A();
            }
    
            static B Method3(B b)
            {
                Console.WriteLine("Method3");
                return new B();
            }
    
            public delegate A MyDelegate(B b);
            static void Main(string[] args)
            {
                MyDelegate myDel = null;
                myDel = Method2;// normal assignment as per parameter and return type
    
                //Covariance,  delegate expects a return type of base class
                //but we can still assign Method3 that returns derived type and 
                //Thus, covariance allows you to assign a method to the delegate that has a less derived return type.
                myDel = Method3;
                A a = myDel(new B());//this will return a more derived type object which can be assigned to base class reference
    
                //Contravariane is applied to parameters. 
                //Contravariance allows a method with the parameter of a base class to be assigned to a delegate that expects the parameter of a derived class.
                myDel = Method1;
                myDel(new B()); //Contravariance, 
    
            }
        }
    }
