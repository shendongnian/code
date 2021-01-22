     using System;
    	
    	class Program
            {
                static void Main(string[] args)
                {
                    TestRef t = new TestRef();
                    t.Something = "Foo";
    
                    DoSomething(t);
                    Console.WriteLine(t.Something);
    
                }
    
                static public void DoSomething(TestRef t)
                {
                    t = new TestRef();
    				t.Something = "Bar";
                }
            }
    
    
    
        public class TestRef
        {
    	private string s;
            public string Something 
    		{ 
    			get {return s;} 
    			set { s = value; }
    		}
        }
