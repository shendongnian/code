    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    
    namespace Test
    {
    	// port of this JavaScript code with some changes:
    	//   http://www.kevlindev.com/gui/math/intersection/Intersection.js
    	// found here:
    	//   http://stackoverflow.com/questions/563198/how-do-you-detect-where-two-line-segments-intersect/563240#563240
    
    	public class Intersect
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
    			System.Console.WriteLine("----");
    			System.Console.WriteLine("Does");
    			System.Console.WriteLine("  " + a1 + " -- " + a2);
    			System.Console.WriteLine("intersect with");
    			System.Console.WriteLine("  " + b1 + " -- " + b2);
    			System.Console.WriteLine("and if so, where?");
    			PointF[] result = Intersection(a1, a2, b1, b2);
    			PrintPoints(result);
    		}
    
    		public static void Main()
    		{
    			// lines segments intersect
    			TestIntersect(new PointF(0, 0),
    						  new PointF(100, 100),
    						  new PointF(100, 0),
    						  new PointF(0, 100));
    			TestIntersect(new PointF(5, 17),
    			              new PointF(100, 100),
    			              new PointF(100, 29),
    			              new PointF(8, 100));
    			// just touching points and lines cross
    			TestIntersect(new PointF(0, 0),
    						  new PointF(25, 25),
    						  new PointF(25, 25),
    						  new PointF(100, 75));
    
    			// parallel
    			TestIntersect(new PointF(0, 0),
    						  new PointF(0, 100),
    						  new PointF(100, 0),
    						  new PointF(100, 100));
    			// lines cross but segments don't intersect
    			TestIntersect(new PointF(50, 50),
    						  new PointF(100, 100),
    						  new PointF(0, 25),
    						  new PointF(25, 0));
    
    			// touching points and coincident!
    			TestIntersect(new PointF(0, 0),
    						  new PointF(25, 25),
    						  new PointF(25, 25),
    						  new PointF(100, 100));
    
    			// overlap/coincident
    			TestIntersect(new PointF(0, 0),
    						  new PointF(75, 75),
    						  new PointF(25, 25),
    						  new PointF(100, 100));
    			TestIntersect(new PointF(0, 0),
    			              new PointF(100, 100),
    			              new PointF(0, 0),
    			              new PointF(100, 100));
    
    			// coincident but do not overlap!
    			TestIntersect(new PointF(0, 0),
    						  new PointF(25, 25),
    						  new PointF(75, 75),
    						  new PointF(100, 100));
    
    			while (!System.Console.KeyAvailable) { }
    		}
    
    		public class Pair
    		{
    			public float index;
    			public PointF p;
    			public Pair(float index, PointF p)
    			{
    				this.index = index;
    				this.p = p;
    			}
    
    			public static int Compare(Pair a, Pair b)
    			{
    				if (a.index < b.index)
    					return -1;
    				else if (a.index > b.index)
    					return 1;
    				else
    					return 0;
    			}
    		}
    
    		public static PointF[] Intersection(PointF a1, PointF a2, PointF b1, PointF b2)
    		{
    			float ua_t = (b2.X - b1.X) * (a1.Y - b1.Y) - (b2.Y - b1.Y) * (a1.X - b1.X);
    			float ub_t = (a2.X - a1.X) * (a1.Y - b1.Y) - (a2.Y - a1.Y) * (a1.X - b1.X);
    			float u_b = (b2.Y - b1.Y) * (a2.X - a1.X) - (b2.X - b1.X) * (a2.Y - a1.Y);
    			if (!(-Single.Epsilon < u_b && u_b < Single.Epsilon))   // e.g. u_b != 0.0
    			{
    				float ua = ua_t / u_b;
    				float ub = ub_t / u_b;
    				if (0.0f <= ua && ua <= 1.0f && 0.0f <= ub && ub <= 1.0f)
    				{
    					// Intersection
    					return new PointF[] { new PointF(a1.X + ua * (a2.X - a1.X), a1.Y + ua * (a2.Y - a1.Y)) };
    				}
    				else
    				{
    					// No Intersection
    					return new PointF[] { };
    				}
    			}
    			else
    			{
    				if ((-Single.Epsilon < ua_t && ua_t < Single.Epsilon)
    				   || (-Single.Epsilon < ub_t && ub_t < Single.Epsilon))
    				{
    					// Coincident
    					// find the common overlapping section of the lines
    					// first find the distance (squared) from one point (a1) to each point
    					float da2a1x = a2.X - a1.X;
    					float da2a1y = a2.X - a1.X;
    					float db1a1x = b1.X - a1.X;
    					float db1a1y = b1.X - a1.X;
    					float db2a1x = b2.X - a1.X;
    					float db2a1y = b2.X - a1.X;
    					float a1_d_sqrd = 0.0f;
    					float a2_d_sqrd = da2a1x * da2a1x + da2a1y * da2a1y;
    					float b1_d_sqrd = db1a1x * db1a1x + db1a1y * db1a1y;
    					float b2_d_sqrd = db2a1x * db2a1x + db2a1y * db2a1y;
    					List<Pair> dists_sqrd = new List<Pair>(4);
    					dists_sqrd.Add(new Pair(a1_d_sqrd, a1));
    					dists_sqrd.Add(new Pair(a2_d_sqrd, a2));
    					dists_sqrd.Add(new Pair(b1_d_sqrd, b1));
    					dists_sqrd.Add(new Pair(b2_d_sqrd, b2));
    					dists_sqrd.Sort(Pair.Compare);
    
    					PointF midp = dists_sqrd[1].p;
    					PointF midq = dists_sqrd[2].p;
    
    					// TODO check if the lines even overlap!
    					// NOTE I'm working on this but I had to restart my computer and close my browser
    
    					return new PointF[] { new PointF(a1.X + ua_t * (a2.X - a1.X), a1.Y + ua_t * (a2.Y - a1.Y)),
    										  new PointF(a1.X + ub_t * (a2.X - a1.X), a1.Y + ub_t * (a2.Y - a1.Y)) };
    				}
    				else
    				{
    					// Parallel
    					return new PointF[] { };
    				}
    			}
    		}
    	}
    }
