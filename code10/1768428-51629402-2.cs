    public class AlternateColorDataTemplateSelector : DataTemplateSelector
	{
		public DataTemplate EvenTemplate { get; set; }
		public DataTemplate UnevenTemplate { get; set; }
		private List<string> flatList;
		protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
		{
			if (flatList == null)
			{
				var groupedList = (ObservableCollection<Grouping<string, string>>)((ListView)container).ItemsSource;
				flatList = groupedList.SelectMany(group => group).ToList();
			}
			return flatList.IndexOf(item as string) % 2 == 0 ? EvenTemplate : UnevenTemplate;
		}
	}
