    using System;
    using System.Linq;
    using System.Drawing;
    
    class Example
    {
    	static void Main()
    	{
    		Point[] points = new Point[] 
    		{ 
    			new Point(2,2),
    			new Point(3,1),
    			new Point(3,2),
    			new Point(1,3)
    		};
    
    		var sortedPoints = points
    				.OrderBy(p => p.X)
    				.ThenBy(p => p.Y);
    	}
    }
