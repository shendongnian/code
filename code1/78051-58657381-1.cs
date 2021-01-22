    namespace View.Helper
    {
    	public class EventToCommandAdaptor
    	{
    		public static readonly DependencyProperty TreeViewSelectedItemChangedCommand_DpProp =
    			DependencyProperty.RegisterAttached(
    			  "TreeViewSelectedItemChangedCommand",
    			  typeof(ICommand),
    			  typeof(EventToCommandAdaptor), // owner type
    			  new PropertyMetadata(new PropertyChangedCallback(AttachOrRemoveTreeViewSelectedItemChangedEvent))
    			  );
    
    		public static ICommand GetTreeViewSelectedItemChangedCommand(DependencyObject obj)
    		{
    			return (ICommand)obj.GetValue(TreeViewSelectedItemChangedCommand_DpProp);
    		}
    
    		public static void SetTreeViewSelectedItemChangedCommand(DependencyObject obj, ICommand value)
    		{
    			obj.SetValue(TreeViewSelectedItemChangedCommand_DpProp, value);
    		}
    
    		public static void AttachOrRemoveTreeViewSelectedItemChangedEvent(DependencyObject obj, DependencyPropertyChangedEventArgs args)
    		{
    			TreeView treeview = obj as TreeView;
    			if (treeview != null)
    			{
    				ICommand cmd = (ICommand)args.NewValue;
    
    				if (args.OldValue == null && args.NewValue != null)
    				{
    					treeview.SelectedItemChanged += ExecuteTreeViewSelectedItemChanged;
    				}
    				else if (args.OldValue != null && args.NewValue == null)
    				{
    					treeview.SelectedItemChanged -= ExecuteTreeViewSelectedItemChanged;
    				}
    			}
    		}
    
    		private static void ExecuteTreeViewSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> args)
    		{
    			DependencyObject obj = sender as DependencyObject;
    			ICommand cmd = (ICommand)obj.GetValue(TreeViewSelectedItemChangedCommand_DpProp);
    
    			if (cmd != null)
    			{
    				if (cmd.CanExecute(args.NewValue))
    				{
    					cmd.Execute(args.NewValue);
    				}
    			}
    		}
    	}
    }
    
