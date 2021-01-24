	using System;
	using System.Collections.Generic;
						
	public class Program
	{
		public static void Main()
		{
			var lst1 = new List<A>();
			var lst2 = new List<B>();
			var result = Merge<ICommon>(lst1, lst2);
		}
		
		public static IEnumerable<T> Merge<T>(IEnumerable<T> a, IEnumerable<T> b){
			foreach(var itm in a)
				yield return itm;
			foreach(var itm in b)
				yield return itm;
		}
	}
	public interface ICommon {}
	public class A : ICommon{}
	public class B : ICommon{}
