    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		Console.WriteLine(new Child().Test);
    	}
    	
    	public class Child : Parent {
    		public Child() : base(false) {
    			//No Parent Constructor called
    		}
    	}
    	public class Parent {
    		public int Test {get;set;}
    		public Parent()
    		{
    			Test = 5;
    		}
    		public Parent(bool NoBase){
    			//Don't do anything
    		}
    	}
    }
