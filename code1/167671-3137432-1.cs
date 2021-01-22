	public class ImmutableWidgetList : IEnumerable<Widget>
	{
		private List<Widget> _widgets;  // we never modify the list
		// creates an empty list
		public ImmutableWidgetList()
		{
			_widgets = new List<Widget>();
		}
		// creates a list from an enumerator
		public ImmutableWidgetList(IEnumerable<Widget> widgetList)
		{
			_widgets = new List<Widget>(widgetList);
		}
		// add a single item
		public ImmutableWidgetList Add(Widget widget)
		{
			List<Widget> newList = new List<Widget>(_widgets);
			ImmutableWidgetList result = new ImmutableWidgetList();
			result._widgets = newList;
			return result;
		}
		// add a range of items.
		public ImmutableWidgetList AddRange(IEnumerable<Widget> widgets)
		{
			List<Widget> newList = new List<Widget>(_widgets);
			newList.AddRange(widgets);
			ImmutableWidgetList result = new ImmutableWidgetList();
			result._widgets = newList;
			return result;
		}
		// implement IEnumerable<Widget>
		IEnumerator<Widget> IEnumerable<Widget>.GetEnumerator()
		{
			return _widgets.GetEnumerator();
		}
		
		// implement IEnumerable
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return _widgets.GetEnumerator();
		}
	}
