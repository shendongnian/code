    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		A objA = new A();
    		objA.printA();
    		B objB = new B();
    		objB.printB();
    		
    	}
    }
    
    abstract class Parent{
    	
    	public int a = 5;
    	
    }
    
    class A : Parent
    {
    	public void printA()
    	{
    		Console.WriteLine("In class A, value is "+a);
    	}
    }
    
    class B : Parent
    {
    	public void printB()
    	{
    		Console.WriteLine("In class B, value is "+a);
    	}
    }
