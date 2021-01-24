	public class TreeViewItemContext
	{
		public ObservableCollection<TreeViewItemContext> Children { get; }
		public MyObject Wrapped { get; }
		
		/* Other properties etc. go in here. */
		
		public TreeViewItemContext(MyObject wrapped)
		{
			this.Children = new ObservableCollection<TreeViewItemContext>();
			this.Wrapped = wrapped;
		}
		
		public IEnumerable<TreeViewItemContext> IterateTree()
		{
			yield return this;
			foreach (var tvic in this.Children)
			{
				foreach (var it in tvic.IterateTree())
				{
					yield return it;
				}
			}
		}
	}
