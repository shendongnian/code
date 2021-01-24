	public class CategoryComparer : IComparer
	{
		private readonly List<string> _categories;
		public int Compare(object x, object y)
		{
			Item item1 = x as Item;
			Item item2 = y as Item;
			int index1 = _categories.IndexOf(item1.CategoryName);
			int index2 = _categories.IndexOf(item2.CategoryName);
			return index1 - index2;
		}
		public CategoryComparer(List<string> categories)
		{
			_categories = categories;
		}
	}
	
