    <DataGridCheckBoxColumn x:Name="col0" HeaderStyle="{StaticResource ColumnHeaderGripperStyle}" DisplayIndex="0">
    private void CheckUnCheckAll(object sender, RoutedEventArgs e)
    {
    	var chkSelectAll = sender as CheckBox;
    	var firstCol = dgUsers.Columns.OfType<DataGridCheckBoxColumn>().FirstOrDefault(c => c.DisplayIndex == 0);
    	if (chkSelectAll == null || firstCol == null || dgUsers?.Items == null)
    	{
    		return;
    	}
    	foreach (var item in dgUsers.Items)
    	{
    		var chBx = firstCol.GetCellContent(item) as CheckBox;
    		if (chBx == null)
    		{
    			continue;
    		}
    		chBx.IsChecked = chkSelectAll.IsChecked;
    	}
    }
