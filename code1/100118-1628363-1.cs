    public void SubscribeAndRun()
    {
    	MyDelegate d = new MyDelegate(Add);
    
    	d += Multiply;
    
    	d.Invoke(2, 3);
    }
