    class Test 
    {
        private string val; 
    	public ref string Val {get {return ref val;}}
    }
    
    
    void Main()
    {
    	Test t = new Test();
    	t.Val = "a";
    	
    	Console.WriteLine("t.Val is - " + t.Val);
    }
 
