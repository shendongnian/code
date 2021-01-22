    public class FruitTemplateSelector : DataTemplateSelector
	{
		public override DataTemplate SelectTemplate(object item, DependencyObject container)
		{
			string templateKey = null;
			if (item is Orange)
			{
				templateKey = "OrangeTemplate";
			}
			else if (item is Apple)
			{
				templateKey = "AppleTemplate";
			}
			if (templateKey != null)
			{
				return (DataTemplate)((FrameworkElement)container).FindResource(templateKey);
			}
			else
			{
				return base.SelectTemplate(item, container);
			}
		}
	}
