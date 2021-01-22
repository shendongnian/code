    using System;
    using C=System.Console;
    
    namespace Foo
    {
    	public class Bar
    	{
    		public static void Main(string[] args)
    		{
    			myImplementationOfTest miot = new myImplementationOfTest();
    			miot.myVirtualMethod();
    			miot.myOtherVirtualMethod();
    			miot.myProperty = 42;
    			miot.myAbstractMethod();
    		}
    	}
    
    	public abstract class test
    	{
    		public abstract int myProperty
    		{
    			get;
    			set;
    		}
    
    		public abstract void myAbstractMethod();
    
    		public virtual void myVirtualMethod()
    		{
    			C.WriteLine("foo");
    		}
    
    		public virtual void myOtherVirtualMethod()
    		{
    		}
    	}
    
    	public class myImplementationOfTest : test
    	{
    		private int _foo;
    		public override int myProperty
    		{
    			get { return _foo; }
    			set { _foo = value; }
    		}
    
    		public override void myAbstractMethod()
    		{
    			C.WriteLine(myProperty);
    		}
    
    		public override void myOtherVirtualMethod()
    		{
    			C.WriteLine("bar");
    		}
    	}
    }
