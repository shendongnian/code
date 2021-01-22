	using System;
	using System.Collections.Generic;
	using System.Linq;
	namespace ConsoleApplication1
	{
		public static class LinqCombinedSort
		{
			public static void Test()
			{
				var a = new[] {'a', 'b', 'c', 'd', 'e', 'f'};
				var b = new[] {3, 2, 1, 6, 5, 4};
				var sorted = from ab in a.Combine(b)
							 orderby ab.Second
							 select ab.First;
				foreach(char c in sorted)
				{
					Console.WriteLine(c);
				}
			}
			public static IEnumerable<Pair<TFirst, TSecond>> Combine<TFirst, TSecond>(this IEnumerable<TFirst> s1, IEnumerable<TSecond> s2)
			{
				using (var e1 = s1.GetEnumerator())
				using (var e2 = s2.GetEnumerator())
				{
					while (e1.MoveNext() && e2.MoveNext())
					{
						yield return new Pair<TFirst, TSecond>(e1.Current, e2.Current);
					}
				}
			}
		}
		public class Pair<TFirst, TSecond>
		{
			private readonly TFirst _first;
			private readonly TSecond _second;
			private int _hashCode;
			public Pair(TFirst first, TSecond second)
			{
				_first = first;
				_second = second;
			}
			public TFirst First
			{
				get
				{
					return _first;
				}
			}
			public TSecond Second
			{
				get
				{
					return _second;
				}
			}
			public override int GetHashCode()
			{
				if (_hashCode == 0)
				{
					_hashCode = (ReferenceEquals(_first, null) ? 213 : _first.GetHashCode())*37 +
								(ReferenceEquals(_second, null) ? 213 : _second.GetHashCode());
				}
				return _hashCode;
			}
			public override bool Equals(object obj)
			{
				var other = obj as Pair<TFirst, TSecond>;
				if (other == null)
				{
					return false;
				}
				return Equals(_first, other._first) && Equals(_second, other._second);
			}
		}
	}
