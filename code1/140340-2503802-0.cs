	public static class Extensions
	{
		public static IEnumerable<Tuple<DateTime, int>> FillMissing(this IEnumerable<Tuple<DateTime, int>> list)
		{
			if(list.Count() == 0)
				yield break;
			DateTime lastDate = list.First().Item1;
			foreach(var tuple in list)
			{
				lastDate = lastDate.AddMonths(1);
				while(lastDate < tuple.Item1)
				{
					yield return new Tuple<DateTime, int>(lastDate, 0);
					lastDate = lastDate.AddMonths(1);
				}
				yield return tuple;
				lastDate = tuple.Item1;
			}
		}
	}
