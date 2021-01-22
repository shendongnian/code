    if (d is ComboBox || d is TextBox)
    {
    	control.GotKeyboardFocus += Control_GotKeyboardFocus;
    	control.LostKeyboardFocus += Control_Loaded;
    
    	if (d is TextBox)
    		(d as TextBox).TextChanged += Control_TextChanged;
    }
    private static void Control_TextChanged(object sender, RoutedEventArgs e)
    {
    	var tb = (TextBox)sender;
    	if (ShouldShowWatermark(tb))
    	{
    		ShowWatermark(tb);
    	}
    	else
    	{
    		RemoveWatermark(tb);
    	}
    }
