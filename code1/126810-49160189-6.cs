    //Assembly.dll
    namespace TestAssembly{
    	public class Main{
    		
    		public void Hello()
    		{ 
    			var name = Console.ReadLine();
    			Console.WriteLine("Hello() called");
    			Console.WriteLine("Hello" + name + " at " + DateTime.Now);
    		}
    		
    		public void Run(string parameters)
            { 
    			Console.WriteLine("Run() called");
                Console.Write("You typed:"  + parameters);
            }
    		
    		public string TestNoParameters()
            {
                Console.WriteLine("TestNoParameters() called");
    			return ("TestNoParameters() called");
            }
    
    		public void Execute(object[] parameters)
            { 
    			Console.WriteLine("Execute() called");
               Console.WriteLine("Number of parameters received: "  + parameters.Length);
    
    		   for(int i=0;i<parameters.Length;i++){
    			   Console.WriteLine(parameters[i]);
    		   }
            }
    		
    	}
    }
