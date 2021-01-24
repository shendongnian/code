    public void MethodWrapper(Action action)
    {
    	Console.WriteLine("begin");
    	action.Invoke();
    	Console.WriteLine("end");
    }
