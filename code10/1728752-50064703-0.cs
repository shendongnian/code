	var SelectedList = new List<checkedBoxIte>();
	StringBuilder aa = new StringBuilder();
	for (int i = 0; i < dataGrid1.Items.Count; i++)
	{
		var item = dataGrid1.Items[i];
		var mycheckbox = dataGrid1.Columns[1].GetCellContent(item) as CheckBox;
		var myTextBlock = dataGrid1.Columns[0].GetCellContent(item) as TextBlock;
		if ((bool)mycheckbox.IsChecked)
		{
			SelectedList.Add(item[i]);
			aa.Append(myTextBlock.Text);
		}
	}
