    using System;
    using System.Collections.Generic;
    
    abstract class ClassName {
    
     public abstract string Name {get;}
    
    }
    
    class Unique : ClassName
    {
        public override string Name {
    	get{return "UniqueName?";}
    	}
        public Unique()
        {
        }
    }
    
    class YAunique : ClassName
    {
        public override string Name {
    		get{return "YetAnotherName";}
    	}
        public YAunique()
        {
           
        }
    }
    					
    public class Program
    {
    	public static void Main()
    	{
    		Dictionary<string, ClassName> doesThisWork = new Dictionary<string, ClassName>();
            doesThisWork.Add("test", new Unique());
            doesThisWork.Add("test2", new YAunique());
    
            Console.WriteLine(doesThisWork["test"].Name);
            Console.WriteLine(doesThisWork["test2"].Name); 
    	}
    }
