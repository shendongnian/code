    public class X
    {
    	public event EventHandler<EventArgs> MyFunnyEvent = delegate() { }
    
    	public void DoSomething()
    	{
    		MyFunnyEvent(this, new EventArgs());
    	}
    }
    
    
    X x = new X();
    
    x.MyFunnyEvent += delegate() { Console.WriteLine("Howdie"); }
    
    x.DoSomething(); // works fine
    
    // .. re-init x
    x.MyFunnyEvent = null;
    
    // .. continue
    x.DoSomething(); // crashes with an exception
     
