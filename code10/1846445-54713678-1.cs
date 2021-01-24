    struct bar
    {
    	public int myprop;
    }
    
    struct bash 
    {
    	public bar mybar;
    }
    
    void Main()
    {
    	bash bash1 = new bash();
    	bash1.mybar.myprop = 1;
    	Console.WriteLine(bash1.mybar.myprop); //Outputs 1 (Direct access)
    	bar bar2 = bash1.mybar;
    	bar2.myprop = 2;
    	Console.WriteLine(bash1.mybar.myprop); //Outputs 1 (Bug: access via a copy)
    	ref bar bar3 = ref bash1.mybar;
    	bar3.myprop = 3;
    	Console.WriteLine(bash1.mybar.myprop); //Outputs 3 (Ref Local)
    	bar3 = new bar();
    	bar3.myprop = 4;
    	Console.WriteLine(bash1.mybar.myprop); //Outputs 4 (Ref local with assignment)
    }
