    using System;
    
    public class Program
    {
    	public static void Main()
    	{		
    		Console.Write("Test 1:");
    		TestBoolLogic(true, true, 0);
    		Console.Write("Test 2:");
    		TestBoolLogic(true, true, 1);
    		Console.Write("Test 3:");
    		TestBoolLogic(true, true, 2);
    		Console.Write("Test 4:");
    		TestBoolLogic(false, true, 0);
    		Console.Write("Test 5:");
    		TestBoolLogic(false, true, 1);
    		Console.Write("Test 6:");
    		TestBoolLogic(false, true, 2);
    	}
    	
    	public static void TestBoolLogic(bool validateNames, bool isOnline, int players){
    		if(validateNames || (isOnline && players > 1)){
    			Console.WriteLine("Validating names");
    		}else{
    			Console.WriteLine("No validation");
    		}
    	}
    }
