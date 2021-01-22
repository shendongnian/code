	public partial class Category
	{
		public IOrderedEnumerable<SubCategory> SubCategories
		{
			get { return _subCategories.OrderBy(s => s.Name); }
		}
	}
