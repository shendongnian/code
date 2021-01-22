    using System.Windows;
    using System.Windows.Controls;
    using System.Collections.Specialized;
    
    namespace WPF
    {
    	public partial class TreeViewEx : TreeView
    	{
    		#region Overrides
    
    		protected override
    		DependencyObject GetContainerForItemOverride()
    		{
    			return new TreeViewItemEx();
    		}
    		protected override bool IsItemItsOwnContainerOverride
    		(
    			object item
    		)
    		{
    			return item is TreeViewItemEx;
    		}
    
    		#endregion
    	}
    	public partial class TreeViewItemEx : TreeViewItem
    	{
    		#region Overrides
    
    		protected override
    
    		DependencyObject GetContainerForItemOverride()
    		{
    			return new TreeViewItemEx();
    		}
    
    		protected override bool IsItemItsOwnContainerOverride
    		(
    			object item
    		)
    		{
    			return item is TreeViewItemEx;
    		}
    		protected override void OnItemsChanged(NotifyCollectionChangedEventArgs e)
    		{
    			switch (e.Action)
    			{
    				case NotifyCollectionChangedAction.Remove:
    					if (HasItems)
    					{
    						int newIndex = e.OldStartingIndex;
    						if (newIndex > 0)
    							--newIndex;
    						TreeViewItemEx item = ItemContainerGenerator.ContainerFromIndex(newIndex) as TreeViewItemEx;
    						item.IsSelected = true;
    					}
    					else
    						base.OnItemsChanged(e);
    					break;
    				default:
    					base.OnItemsChanged(e);
    				break;
    			}
    		}
    		protected override void OnSelected(RoutedEventArgs e)
    		{
    			base.OnSelected(e);
    			Focus();
    		}
    
    		#endregion
    	}
    }
