    public class ListBoxSelection : Behavior<ListBox>
    {
    	public static readonly DependencyProperty LastSelectedProperty = DependencyProperty.Register(nameof(LastSelected), typeof(object), typeof(ListBoxSelection), new PropertyMetadata(default(object)));
    
    	public object LastSelected
    	{
    		get
    		{
    			return (object)GetValue(LastSelectedProperty);
    		}
    		set
    		{
    			SetValue(LastSelectedProperty, value);
    		}
    	}
    
    	protected override void OnAttached()
    	{
    		base.OnAttached();
    
    		AssociatedObject.SelectionChanged += AssociatedObject_SelectionChanged;
    	}
    
    	private void AssociatedObject_SelectionChanged(object sender, SelectionChangedEventArgs e)
    	{
    //you can also use whatever logic if you evaluate e.RemovedItems and e.AddedItems
    		if ((AssociatedObject?.SelectedItems?.Count??0)>0)
    		{
    			LastSelected = AssociatedObject.SelectedItems[AssociatedObject.SelectedItems.Count-1];
    		}
    		else
    		{
    			LastSelected = null;
    		}
    			
    	}
    
    	protected override void OnDetaching()
    	{
    		base.OnDetaching();
    		AssociatedObject.SelectionChanged -= AssociatedObject_SelectionChanged;
    	}
    }
    
