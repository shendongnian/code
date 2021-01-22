    public class X
    {
        public delegate void MyDelegate();
    	public MyDelegate MyFunnyCallback = delegate() { }
    
    	public void DoSomething()
    	{
    		MyFunnyCallback();
    	}
    }
    
    
    X x = new X();
    
    x.MyFunnyCallback = delegate() { Console.WriteLine("Howdie"); }
    
    x.DoSomething(); // works fine
    
    // .. re-init x
    x.MyFunnyCallback = null;
    
    // .. continue
    x.DoSomething(); // crashes with an exception
     
