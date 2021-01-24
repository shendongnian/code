    public class TreeViewSelection : Behavior<TreeView>
    {
    	public static readonly DependencyProperty CurrentSelectionProperty = DependencyProperty.Register("CurrentSelection", typeof(object), typeof(TreeViewSelection), new PropertyMetadata(default(object)));
    
    	public object CurrentSelection
    	{
    		get
    		{
    			return (object)GetValue(CurrentSelectionProperty);
    		}
    		set
    		{
    			SetValue(CurrentSelectionProperty, value);
    		}
    	}
    
    	protected override void OnAttached()
    	{
    		base.OnAttached();
    
    		AssociatedObject.SelectedItemChanged += TreeView_SelectedItemChanged;
    	}
    
    	private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
    	{
    		CurrentSelection = e.NewValue;
    	}
    
    	protected override void OnDetaching()
    	{
    		base.OnDetaching();
    		AssociatedObject.SelectedItemChanged -= TreeView_SelectedItemChanged;
    	}
    }
