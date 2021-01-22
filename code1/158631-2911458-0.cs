    public class ScrollableCheckboxList<TModel>
		where TModel : class
	{
		public List<ScrollableCheckboxItem> listitems;
		public ScrollableCheckboxList(IEnumerable<TModel> items, string valueField, string textField, string titleField)
		{
			listitems = new List<ScrollableCheckboxItem>();
			foreach (TModel item in items)
			{
				Type t = typeof(TModel);
				PropertyInfo[] props = new [] { t.GetProperty(textField), t.GetProperty(valueField), t.GetProperty(titleField) };
				listitems.Add(new ScrollableCheckboxItem
				{
					text = props[0].GetValue(item, null).ToString(),
					value = props[1].GetValue(item, null).ToString(),
					title = props[2].GetValue(item, null).ToString()
				});
			}
		}
	}
