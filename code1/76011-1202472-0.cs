    using System;
    using System.Collections.Generic;
    
    class Program
    {
    	static void Main()
    	{
    		List<User> users = new List<User>
    		{
    			// use a List<T> to hold the users themselves
    		};
    	}
    }
    
    class Group
    {
    	public Group NestedGroup { get; set; }
    }
    
    class User
    {
    	// Store the groups in a HashSet<T> to keep
    	// a distinct list.
    	HashSet<Group> groups;
    
    	public IEnumerable<Group> Groups
    	{
    		get { return groups; }
    	}
    }
