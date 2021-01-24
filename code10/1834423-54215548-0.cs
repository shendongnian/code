    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Collections;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var parents = new List<Parent>();
    		parents.Add(new Parent{ChildId = "123"});
    		parents.Add(new Parent{ChildId = "321"});
    		parents.Add(new Parent{ChildId = "456"});
    		
    		var result = ChildHelpers.OrderChildren(parents);
    		
    		foreach(var res in result) {
    			Console.WriteLine(res.ChildId);
    		}
    		Console.WriteLine("Hello World");
    	}
    }
    
    public interface IChild {
    	string ChildId {get;set;}
    }
    
    public class Child : IChild {
    	public string Name {get;set;}
    	public string ChildId {get;set;}
    }
    
    public class Parent : IChild {
    	public Parent() {
    		child = new Child();
    	}
    	public Child child {get;set;}
    	public string ChildId {
    		get{
    			return child.ChildId;
    		}
    		set{
    			child.ChildId = value;
    		}
    	}
    }
    
    public class AnotherChild : IChild {
    	public string Description{get;set;}
    	public string ChildId {get;set;}
    }
    
    public static class ChildHelpers {
    	public static IEnumerable<IChild> OrderChildren(IEnumerable<IChild> children)
        {
            return children.OrderBy(c=>c.ChildId).AsEnumerable();
        }
    }
