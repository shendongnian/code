    using System;
    using System.Collections.Generic;
    using System.Linq;
    					
    public class Program
    {
    	public  void Main()
    	{
    		List<List<ABC>> myList = new List<List<ABC>>();
    		
    		List<ABC> tList = new List<ABC>();    
    		tList.Add(new ABC(){QuestionName = "EFirstName", Response = "BBB"});
            tList.Add(new ABC(){QuestionName = "BLastName", Response = "BBBLastName"});
            myList.Add(tList);
    		
    		List<ABC> bList = new List<ABC>();    
    		tList.Add(new ABC(){QuestionName = "zFirstName", Response = "BBB"});
            tList.Add(new ABC(){QuestionName = "QLastName", Response = "BBBLastName"});
            myList.Add(bList);
    		
    		Console.WriteLine("Normal List");
    		foreach(var item in myList){
    			foreach(var innerItem in item){
    		        Console.WriteLine(innerItem.QuestionName);
    			}
    		}
    		
    		Console.WriteLine("++++++++++++++++++++++++");
            // Sort
    		var sortedList = myList.Select(x=>x.OrderBy(y=> y.QuestionName)).ToList();
    	    Console.WriteLine("Sorted List");
    		foreach(var item in sortedList){
    			foreach(var innerItem in item){
    		        Console.WriteLine(innerItem.QuestionName);
    			}
    		}
    		
    	}
    }
