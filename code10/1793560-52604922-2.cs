    private void ComboBoxItem_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
    	var cat_obj = (sender as ComboBoxItem).Content as Modell;
    
    	if (cat_obj.id == 0)
    	{
    		testCombo.SelectedIndex = -1;
    		e.Handled = true;
    		testCombo.IsDropDownOpen = false;
    	}
    }
 
