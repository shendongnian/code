    	public class IntersectTest
    	{
    		public static void PrintPoints(PointF[] pf)
    		{
    			if (pf == null || pf.Length < 1)
    				System.Console.WriteLine("Doesn't intersect");
    			else if (pf.Length == 1)
    			{
    				System.Console.WriteLine(pf[0]);
    			}
    			else if (pf.Length == 2)
    			{
    				System.Console.WriteLine(pf[0] + " -- " + pf[1]);
    			}
    		}
    
    		public static void TestIntersect(PointF a1, PointF a2, PointF b1, PointF b2)
    		{
    			System.Console.WriteLine("----------------------------------------------------------");
    			System.Console.WriteLine("Does      " + a1 + " -- " + a2);
    			System.Console.WriteLine("intersect " + b1 + " -- " + b2 + " and if so, where?");
    			System.Console.WriteLine("");
    			PointF[] result = Intersect.Intersection(a1, a2, b1, b2);
    			PrintPoints(result);
    		}
    
    		public static void Main()
    		{
    			System.Console.WriteLine("----------------------------------------------------------");
    			System.Console.WriteLine("line segments intersect");
    			TestIntersect(new PointF(0, 0),
    						  new PointF(100, 100),
    						  new PointF(100, 0),
    						  new PointF(0, 100));
    			TestIntersect(new PointF(5, 17),
    						  new PointF(100, 100),
    						  new PointF(100, 29),
    						  new PointF(8, 100));
    			System.Console.WriteLine("----------------------------------------------------------");
    			System.Console.WriteLine("");
    
    			System.Console.WriteLine("----------------------------------------------------------");
    			System.Console.WriteLine("just touching points and lines cross");
    			TestIntersect(new PointF(0, 0),
    						  new PointF(25, 25),
    						  new PointF(25, 25),
    						  new PointF(100, 75));
    			System.Console.WriteLine("----------------------------------------------------------");
    			System.Console.WriteLine("");
    
    			System.Console.WriteLine("----------------------------------------------------------");
    			System.Console.WriteLine("parallel");
    			TestIntersect(new PointF(0, 0),
    						  new PointF(0, 100),
    						  new PointF(100, 0),
    						  new PointF(100, 100));
    			System.Console.WriteLine("----------------------------------------------------------");
    			System.Console.WriteLine("");
    
    			System.Console.WriteLine("----");
    			System.Console.WriteLine("lines cross but segments don't intersect");
    			TestIntersect(new PointF(50, 50),
    						  new PointF(100, 100),
    						  new PointF(0, 25),
    						  new PointF(25, 0));
    			System.Console.WriteLine("----------------------------------------------------------");
    			System.Console.WriteLine("");
    
    			System.Console.WriteLine("----------------------------------------------------------");
    			System.Console.WriteLine("coincident but do not overlap!");
    			TestIntersect(new PointF(0, 0),
    						  new PointF(25, 25),
    						  new PointF(75, 75),
    						  new PointF(100, 100));
    			System.Console.WriteLine("----------------------------------------------------------");
    			System.Console.WriteLine("");
    
    			System.Console.WriteLine("----------------------------------------------------------");
    			System.Console.WriteLine("touching points and coincident!");
    			TestIntersect(new PointF(0, 0),
    						  new PointF(25, 25),
    						  new PointF(25, 25),
    						  new PointF(100, 100));
    			System.Console.WriteLine("----------------------------------------------------------");
    			System.Console.WriteLine("");
    
    			System.Console.WriteLine("----------------------------------------------------------");
    			System.Console.WriteLine("overlap/coincident");
    			TestIntersect(new PointF(0, 0),
    						  new PointF(75, 75),
    						  new PointF(25, 25),
    						  new PointF(100, 100));
    			TestIntersect(new PointF(0, 0),
    						  new PointF(100, 100),
    						  new PointF(0, 0),
    						  new PointF(100, 100));
    			System.Console.WriteLine("----------------------------------------------------------");
    			System.Console.WriteLine("");
    
    			while (!System.Console.KeyAvailable) { }
    		}
    
    	}
