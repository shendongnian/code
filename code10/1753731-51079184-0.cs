	using System;
	using System.Collections.Generic;
						
	public class Program
	{
		// Answer 1:
		// The downside is that you need to provide your increment 
		// func and you can pass any type implementing 
		// IComparable.Usage: var xd = Numbers<int>(1, 5, x => { x++; return x; });
		public static IEnumerable<T> Numbers<T>(T a, T b, Func<T, T> increment) 
		where T : struct, IComparable 
		{ 
			var i = a; while (i.CompareTo(b) < 0) 
			{ 
				yield return i; i = increment(i); 
			} 
		}
		// Answer 2:
		// Idea without passing increment function but can cause runtime error 
		// if increment is not implemented: 
		public static IEnumerable<T> Numbers<T>(T a, T b)
		where T : struct, IComparable
		{
			dynamic i = a; while (i.CompareTo(b) < 0)
			{
				yield return i; i++;
			}
		}
		public static void Main()
		{
			// implicit increment:
			Numbers<double>(1, 5).Dump();
			
			// explicit increment (+1), example 1:
			Numbers<int>(1, 5, x => {x++; return x;}).Dump();
			
			// explicit increment (+0.75), example 2:
			Numbers<float>((float)1.5, (float)7.5, x => { x += (float)0.75; return x; }).Dump();
		}
	}
