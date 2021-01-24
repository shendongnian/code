    using System;
    
    // C# events start with declaring a delegate
    public delegate void PersonNameChangeEvent(string oldName, string newName);
    
    public class Person
    {
    	// I noticed an oddity in the VB code, in that the data member was
    	// public.  It should be private, especially since there is a property
    	// handler for it
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
    	
    	// a delegate instance is a class member
        public event PersonNameChangeEvent OnNameChange;	
    }
    
    
    public static class Test
    {
        public static void Main(string[] args)
    	{
    	     Person p = new Person();
    		 
    		 // assign a method by using of a lamda expression to the event/delegate
             // this expression will get called in the setter of Person.Name....
    		 // see notifyEvent(old, name)
    		 p.OnNameChange += ((o, n) => { Console.WriteLine(string.Format("Person '{0}' changed to '{1}'", o, n));  } );
    		 
    		 p.Name = "Bob";
    		 p.Name = "Joe";
    	}
    }
