	public enum Item
	{
		Baloon,
		Cupcake,
		Coke
	}
	public static class TableExtensions
	{
		public static Pair<Item, int> Baloons(this int count)
		{
			return Tuple.From(Item.Baloon, count);
		}
		public static Pair<Item, int> Cupcakes(this int count)
		{
			return Tuple.From(Item.Cupcake, count);
		}
		public static bool Contains(this IEnumerable<Item> self, 
			params Pair<Item, int>[] criteria)
		{
			foreach (var pair in criteria)
			{
				var search = pair.Key;
				if (self.Count(item => item == search) < pair.Value)
					return false;
			}
			return true;
		}
	}
