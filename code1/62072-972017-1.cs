	public static class ExtNum{
		public static IEnumerable<T> skipLast<T>(this IEnumerable<T> source){
			if ( ! source.Any())
				yield break;
			for (int i = 0 ; i <=source.Count()-2 ; i++ )
				yield return source.ElementAt(i);
			yield break;
		}
	}
	class Program
	{
		static void Main( string[] args )
		{
			Queue<string> qq = new Queue<string>();
			qq.Enqueue("first");qq.Enqueue("second");qq.Enqueue("third");
			List<string> lq = new List<string>();
			lq.Add("FIRST"); lq.Add("SECOND"); lq.Add("THIRD"); lq.Add("FOURTH");
			foreach(string s1 in qq.skipLast())
				Console.WriteLine(s1);
			foreach ( string s2 in lq.skipLast())
				Console.WriteLine(s2);
		}
	}
