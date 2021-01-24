    using System;
    
    
    public delegate void PersonNameChangeEvent(string oldName, string newName);
    
    public class Person
    {
        private string name;
        public string Name
    	{
    	    get { return name;}
    		set
    		{
    		    string old = name;
    		    name = value;
    			
    			PersonNameChangeEvent notifyEvent = OnNameChange;
    			if (null == OnNameChange)
    			   return;
    			   
    			notifyEvent(old, name);
    		}
    	}
    
        public event PersonNameChangeEvent OnNameChange;	
    }
    
    
    public static class Test
    {
        public static void Main(string[] args)
    	{
    	     Person p = new Person();
    		 
    		 p.OnNameChange += ((o, n) => { Console.WriteLine(string.Format("Person {0} changed to {1}", o, n));  } );
    		 
    		 p.Name = "Bob";
    		 p.Name = "Joe";
    	}
    }
