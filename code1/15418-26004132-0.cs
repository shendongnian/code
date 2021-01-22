		private static readonly Regex _NaturalOrderExpr = new Regex(@"\d+", RegexOptions.Compiled);
		public static IEnumerable<TSource> OrderByNatural<TSource, TKey>(
			this IEnumerable<TSource> source, Func<TSource, TKey> selector)
		{
			int max = 0;
			var selection = source.Select(
				o =>
				{
					var v = selector(o);
					var s = v != null ? v.ToString() : String.Empty;
					if (!String.IsNullOrWhiteSpace(s))
					{
						var mc = _NaturalOrderExpr.Matches(s);
						if (mc.Count > 0)
						{
							max = Math.Max(max, mc.Cast<Match>().Max(m => m.Value.Length));
						}
					}
					return new
					{
						Key = o,
						Value = s
					};
				});
			return
				selection.OrderBy(
					o =>
					String.IsNullOrWhiteSpace(o.Value) ? o.Value : _NaturalOrderExpr.Replace(o.Value, m => m.Value.PadLeft(max, '0')))
						 .Select(o => o.Key);
		}
		public static IEnumerable<TSource> OrderByDescendingNatural<TSource, TKey>(
			this IEnumerable<TSource> source, Func<TSource, TKey> selector)
		{
			int max = 0;
			var selection = source.Select(
				o =>
				{
					var v = selector(o);
					var s = v != null ? v.ToString() : String.Empty;
					if (!String.IsNullOrWhiteSpace(s))
					{
						var mc = _NaturalOrderExpr.Matches(s);
						if (mc.Count > 0)
						{
							max = Math.Max(max, mc.Cast<Match>().Max(m => m.Value.Length));
						}
					}
					return new
					{
						Key = o,
						Value = s
					};
				});
			return
				selection.OrderByDescending(
					o =>
					String.IsNullOrWhiteSpace(o.Value) ? o.Value : _NaturalOrderExpr.Replace(o.Value, m => m.Value.PadLeft(max, '0')))
						 .Select(o => o.Key);
		}
