    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		
            Box Box1 = new Box();   //create new class called Box1
            Box Box2 = new Box();   //create new class called Box2
    
            // box 1 specification
            Box1.Length = 6.0;
            Box1.Breadth = 7.0;
            Box1.Height = 5.0;
    
            // box 2 specification
            Box2.Length = 11.0;
            Box2.Breadth = 16.0;
            Box2.Height = 12.0;
    		
    		Console.WriteLine("Volume of Box1 : {0}", Box1.Volume);
    		Console.WriteLine("Volume of Box2 : {0}", Box2.Volume);     
    		
    	}
    }
    
    public class Box
    {
    	public double Length {get;set;}   // Length of a box
        public double Breadth {get;set;} // Breadth of a box
        public double Height {get;set;}// Height of a box
    	public double Volume { get { return Length * Breadth * Height;}}
    }
