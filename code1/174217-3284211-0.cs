	class ListItem
	{
		internal DateTime When;
		internal decimal Amount;
		internal int Category;
	}
	class ListItems
	{
		internal List<ListItem> _items = new List<ListItem>();
		internal int GetCategory(DateTime from, DateTime to)
		{
			Dictionary<int, decimal> totals = _items.Where(y => y.When >= from && y.When < to).GroupBy(x => x.Category)
				.ToDictionary(category => category.Key, category => category.Sum(item => item.Amount));
			return totals.Keys.Where(category => totals[category] == totals.Values.Max()).First();
		}
	}
