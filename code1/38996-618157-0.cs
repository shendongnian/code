    public delegate void testDelegate(string s, int i);
    
    private void callDelegate()
    {
    	testDelegate td = new testDelegate(Test);
    
    	td.Invoke("my text", 1);
    }
    
    private void Test(string s, int i)
    {
    	Console.WriteLine(s);
    	Console.WriteLine(i.ToString());
    }
