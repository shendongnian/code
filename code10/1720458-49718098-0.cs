    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		C c = new C();
    		A a = new A();
    		Console.WriteLine(a.GetType());
    		a = c;
    		Console.WriteLine(a.GetType());
    		a.Show();
    		c.Show();
    		Console.ReadLine();
    	}
    }
    
    class A
    {
        public virtual void Show()
        {
            Console.WriteLine("A.Show()");
        }
    }
    
    class B : A
    {
        public override void Show()
        {
            Console.WriteLine("B.Show()");
        }
    }
    
    class C : B
    {
        public override void Show()
        {
            Console.WriteLine("C.Show()");
        }
    }
