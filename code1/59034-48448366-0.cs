    Try this this example
    
    using System;
    					
    public class Program
    {
        private Func<string,string> FunctionPTR = null;  
        private Func<string,string, string> FunctionPTR1 = null;  
    	private Action<object> ProcedurePTR = null; 
    		
    		
      
        private string Display(string message)  
        {  
            Console.WriteLine(message);  
            return null;  
        }  
      
        private string Display(string message1,string message2)  
        {  
            Console.WriteLine(message1);  
            Console.WriteLine(message2);  
            return null;  
        }  
    	
    	public void ObjectProcess(object param)
    	{
    		if (param == null)
    		{
    			throw new ArgumentNullException("Parameter is null or missing");
    		}
    		else 
    		{
    			Console.WriteLine("Object is valid");
    		}
    	}
    	
    	
        public void Main(string[] args)  
        {  
            FunctionPTR = Display;  
            FunctionPTR1= Display;  
    		ProcedurePTR = ObjectProcess;
            FunctionPTR("Welcome to function pointer sample.");  
            FunctionPTR1("Welcome","This is function pointer sample");   
    		ProcedurePTR(new object());
        }  
    }
