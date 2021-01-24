    private void PopulateCheckboxes1()
    {
    	for(int idx = 0; idx < 5; idx++)
    	{
    		var chkBox = new CheckBox();
    		chkBox.Content = string.Format($"TextBox: {idx}");
    		chkBox.Tag = idx;
    		chkBox.Checked += ChkBox_Checked;
    		cmbBox1.Items.Add(chkBox);
    	}
    }
    
    private void ChkBox_Checked(object sender, RoutedEventArgs e)
    {
    	var itemsToAdd = (int)(sender as Control).Tag;
    	cmbBox2.Items.Clear();
    	for (int idx = 0; idx < itemsToAdd; idx++)
    	{
    		var chkBox = new CheckBox();
    		chkBox.Content = string.Format($"TextBox: {idx}");
    		cmbBox2.Items.Add(chkBox);
    	}
    }
