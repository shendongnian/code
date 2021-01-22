    using System;
    namespace StackOverflow.Examples
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			NewClass foo = new NewClass("parameter1","parameter2");
    			Console.WriteLine(foo.GetUpperParameter());
    			Console.ReadKey();
    		}
    	}
    	
    	interface IClass
    	{
    		string GetUpperParameter();
    	}
    	
    	class BaseClass : IClass
    	{
    		private string parameter;
    		public BaseClass (string someParameter)
    		{
    			this.parameter = someParameter;
    		}
    		
    		public string GetUpperParameter()
    		{
    			return this.parameter.ToUpper();
    		}
    	}
    	
    	class NewClass : IClass
    	{
    		private BaseClass internalClass;
    		private string newParameter;
    		
    		public NewClass (string someParameter, string newParameter)
    		{
    			this.internalClass = new BaseClass(someParameter);
    			this.newParameter = newParameter;
    		}
    		
    		public string GetUpperParameter()
    		{
    			return this.internalClass.GetUpperParameter() + this.newParameter.ToUpper();
    		}
    	}
    }
