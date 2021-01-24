    public class Parent
    {
        public void foo()
        {
            bar();
        }
    
        public virtual void bar()
        {
            thing_a();
        }
    }
    
    public class Child : Parent
    {
    	public override void bar()
    	{
    		thing_b();
    	}
    }
