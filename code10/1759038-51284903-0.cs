    public class MultipleSelectionListBox : ListBox
    {
    	public static readonly DependencyProperty BindableSelectedItemsProperty =
    		DependencyProperty.Register("BindableSelectedItems",
    			typeof(IList), typeof(MultipleSelectionListBox),
    			new FrameworkPropertyMetadata(default(IList),
    				FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnBindableSelectedItemsChanged));
    
    	public IList BindableSelectedItems
    	{
    		get => (IList)GetValue(BindableSelectedItemsProperty);
    		set => SetValue(BindableSelectedItemsProperty, value);
    	}
    
    	protected override void OnSelectionChanged(SelectionChangedEventArgs e)
    	{
    		base.OnSelectionChanged(e);
    
    		IList selectedItemsList = BindableSelectedItems;
    		if (selectedItemsList == null)
    			selectedItemsList = (IList)Activator.CreateInstance(ItemsSource.GetType());
    		selectedItemsList.Clear();
    
    		foreach (var item in SelectedItems)
    			selectedItemsList.Add(item);
    
    		BindableSelectedItems = selectedItemsList;
    	}
    
    	private static void OnBindableSelectedItemsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    	{
    		if (d is MultipleSelectionListBox listBox)
    			listBox.SetSelectedItems(listBox.BindableSelectedItems);
    	}
    }
