    using System;
    namespace ConsoleApplication4983
    {
    	public class MyClass
    	{
    		static void Main()
    		{
    			var c = new MyClass();
    			c.DoSomething(new Sequential());
    			c.DoSomething(new Random());
    		}
    
    		public void DoSomething(ProcessingMethod method)
    		{
    			method.Foo();
    		}
    	}
    
    	public class ProcessingMethod
    	{
    		public virtual void Foo() { }
    	}
    	public class Sequential : ProcessingMethod
    	{
    		public override void Foo() { }
    	}
    	public class Random : ProcessingMethod
    	{
    		public override void Foo() { }
    	}
    }
