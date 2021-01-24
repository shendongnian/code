    using System;
    using System.Collections.Generic;
    using System.Linq;
    					
    public class Program
    {
    	public static void Main(string[] args)
    	{
    		
    		List<TestClass> lstOfItems = new List<TestClass>();
    		
    		var itemOne = new TestClass(){BranchName = "Branch One", BranchId = 1, DeptId = 1};
    		var itemTwo = new TestClass(){BranchName = "Branch Two", BranchId = 2, DeptId = 1};
    		var itemThree = new TestClass(){BranchName = "Branch Two", BranchId = 2, DeptId = 2};
    		var itemFour = new TestClass(){BranchName = "Branch Three", BranchId = 3, DeptId = 1};
    		var itemFive = new TestClass(){BranchName = "Branch Three", BranchId = 3, DeptId = 2};
    		var itemSix = new TestClass(){BranchName = "Branch Three", BranchId = 3, DeptId = 3};
    		
    		lstOfItems.Add(itemOne);
    		lstOfItems.Add(itemTwo);
    		lstOfItems.Add(itemThree);
    		lstOfItems.Add(itemFour);
    		lstOfItems.Add(itemFive);
    		lstOfItems.Add(itemSix);
    		
    		var myList = lstOfItems.GroupBy(x => x.BranchName).Where(y => y.Count() == 1 && y.First().DeptId == 1).ToList();
    		
    		foreach(var item in myList){
    			Console.WriteLine(item.Key);
    		}
            // Output
            // Branch One
    	
    	}
    }
    
    public class TestClass
    {
    	public string BranchName {get;set;}
    	public int BranchId {get;set;}	
    	public int DeptId {get;set;}
    }
