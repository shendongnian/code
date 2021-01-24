    using System;
    using System.Text;
    using System.Collections.Generic;
    					
    public class Program
    {
    	public static void Main()
    	{
    		Console.WriteLine("Hello World");
    		HashSet<Position> hash = new HashSet<Position>();
    		Position position = new Position(3, 1);
    		Position position2 = new Position(3, 1);
    		hash.Add(position);
    		Console.WriteLine(hash.Contains(position2));
    	}
    }
    
    
    public class Position
     {
         public int row, col;
    	 
    	 public Position(int row, int col) {
    	   this.row =  row;
    		this.col =  col;
    	 }
    	 
    	 public override bool Equals(object obj)
         {
             return ((Position)obj).row == row && ((Position)obj).col == col;
         }
    	
         public override int GetHashCode()
         {
    		 int j;
    		 if (Int32.TryParse(String.Concat(row, col), out j)) {
    			 Console.WriteLine("has code =" + j + row, col);
    			 return j + row, col;
    		 }
    		 else {
    			 return base.GetHashCode();
    		 }
         }
     }
