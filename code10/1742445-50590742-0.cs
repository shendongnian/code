    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class A 
    {
    	public int Id {get; set;}
    	public int BId {get; set;}
    	public string AName {get; set;}
    }
    
    public class B{
    	public int Id {get; set;}
    	public string description{get; set;}
    }
    	
    					
    public class Program
    {
        private static List<A> _aList = new List<A>();	
    	private static List<B> _bList = new List<B>();	
    	
    	public static void Main()
    	{
    		Seed();
    		
    		var query =
    		    from b in _bList
    			group b by b.Id into g
    		   	join a in _aList on g.FirstOrDefault().Id equals a.BId		   
    		   	select new { A_ID = a.Id, Cnt = g.Count(), AName = a.AName};
    		
    		Console.WriteLine("A_ID | count(Id) | AName");
    		foreach(var row in query) 
    		{
    			Console.WriteLine(string.Join(" | ", new string[]{row.A_ID.ToString(), row.Cnt.ToString(), row.AName}));
    		}
    	}
    	
    	public static void Seed() 
    	{		
    		_aList.Add(new A{Id=1, BId=1, AName="A1"});
    		_aList.Add(new A{Id=2, BId=1, AName="A2"});
    		_aList.Add(new A{Id=3, BId=1, AName="A3"});
    		_aList.Add(new A{Id=4, BId=2, AName="A4"});
    		
    		_bList.Add(new B{Id=1, description="B1"});
    		_bList.Add(new B{Id=2, description="B2"});
    	}
    }
