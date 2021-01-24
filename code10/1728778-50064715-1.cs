    using System;
    namespace Program1
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                A oa=new A();
                B ob=new B();
                oa.f(ob);
                Console.WriteLine(ob.b); //8
            }
        }
    }
    class A
    {
        public int a;
        public void f(B ob)
        {
            ob.b=4;
            C oc = new C();
            oc.f(ob);
        }  
    }
    class B
    {
        public int b;
    }
    class C
    {
        public int c;
        public void f(B ob)
        {
            ob.b = 8;
        }  
    }
