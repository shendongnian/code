    using System;
    using System.Collections.Generic;
    
    namespace Ctors
    {
        //Tested with VS2008 SP1
        class A
        {
            //This will be executed before entering any constructor bodies...
            private List<string> myList = new List<string>();
    
            public A() { }
    
            //This will create an unused temp List<string> object 
            //in both Debug and Release build
            public A(List<string> list)
            {
                myList = list;
            }
        }
    
        class B
        {
            private List<string> myList;
    
            //ILs emitted by C# compiler are identicial to 
            //those of public A() in both Debug and Release build 
            public B()
            {
                myList = new List<string>();
            }
    
            //No garbage here
            public B(List<string> list)
            {
                myList = list;
            }
        }
    
        class C
        {
            
            private List<string> myList = null;
            //In Release build, this is identical to B(), 
            //In Debug build, ILs to initialize myList to null is inserted. 
            //So more ILs than B() in Debug build.  
            public C()
            {
                myList = new List<string>();
            }
    
            //This is identical to B(List<string> list) 
            //in both Debug and Release build. 
            public C(List<string> list)
            {
                myList = list;
            }
        }
    
        class D
        {
            //This will be executed before entering a try/catch block
            //in the default constructor
            private E myE = new E();
            public D()
            {
                try
                { }
                catch (NotImplementedException e)
                {
                    //Cannot catch NotImplementedException thrown by E(). 
                    Console.WriteLine("Can I catch here???");
                }
            }
        }
    
        public class E
        {
            public E()
            {
                throw new NotImplementedException();
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                //This will result in an unhandled exception. 
                //You may want to use try/catch block when constructing D objects.
                D myD = new D();
            }
        }
    }
