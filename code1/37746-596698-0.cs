    delegate void PassIntDelegate (int i);
    delegate void PassIntIntCallbackDelegate (int i1, int i2, PassIntDelegate callback);
    
    public int MyFunction (int i1, int i2)
    {
    	return i1 * i2;
    }
    
    public void MyFunctionAsync (int i1, int i2, PassIntDelegate callback)
    {
    	new PassIntIntDelegate (_MyFunctionAsync).BeginInvoke (i1, i2, callback);
    }
    
    private void _MyFunctionAsync (int i1, int i2, PassIntDelegate callback)
    {
    	callback.Invoke (MyFunction (i1, i2));
    }
