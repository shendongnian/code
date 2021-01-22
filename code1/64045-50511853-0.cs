    public class BindableSelectedItem
    {
    	public static readonly DependencyProperty SelectedItemProperty = DependencyProperty.RegisterAttached(
    		"SelectedItem", typeof(object), typeof(BindableSelectedItem), new PropertyMetadata(default(object), OnSelectedItemPropertyChangedCallback));
    
    	private static void OnSelectedItemPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
    	{
    		var treeView = d as TreeView;
    		if (treeView != null)
    		{
    			BrowseTreeViewItems(treeView, tvi =>
    			{
    				tvi.IsSelected = tvi.DataContext == e.NewValue;
    			});
    		}
    		else
    		{
    			throw new Exception("Attached property supports only TreeView");
    		}
    	}
    
    	public static void SetSelectedItem(DependencyObject element, object value)
    	{
    		element.SetValue(SelectedItemProperty, value);
    	}
    
    	public static object GetSelectedItem(DependencyObject element)
    	{
    		return element.GetValue(SelectedItemProperty);
    	}
    
    	public static void BrowseTreeViewItems(TreeView treeView, Action<TreeViewItem> onBrowsedTreeViewItem)
    	{
    		var collectionsToVisit = new System.Collections.Generic.List<Tuple<ItemContainerGenerator, ItemCollection>> { new Tuple<ItemContainerGenerator, ItemCollection>(treeView.ItemContainerGenerator, treeView.Items) };
    		var collectionIndex = 0;
    		while (collectionIndex < collectionsToVisit.Count)
    		{
    			var itemContainerGenerator = collectionsToVisit[collectionIndex].Item1;
    			var itemCollection = collectionsToVisit[collectionIndex].Item2;
    			for (var i = 0; i < itemCollection.Count; i++)
    			{
    				var tvi = itemContainerGenerator.ContainerFromIndex(i) as TreeViewItem;
    				if (tvi == null)
    				{
    					continue;
    				}
    
    				if (tvi.ItemContainerGenerator.Status == System.Windows.Controls.Primitives.GeneratorStatus.ContainersGenerated)
    				{
    					collectionsToVisit.Add(new Tuple<ItemContainerGenerator, ItemCollection>(tvi.ItemContainerGenerator, tvi.Items));
    				}
    
    				onBrowsedTreeViewItem(tvi);
    			}
    
    			collectionIndex++;
    		}
    	}
    
    }
