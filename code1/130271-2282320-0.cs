    class Base
    {
        protected static void Helper(string s)
    	{
    	   Console.WriteLine(s);
    	}
    }
    
    class Subclass : Base
    {
       public void Run()
    	{
    	   Helper("From the subclass");
    	}
    }
