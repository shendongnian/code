    private void Dg_Loaded(object sender, RoutedEventArgs e)
	{
		for (int i = 0; i < dg.Items.Count; i++)
		{
			DataGridRow row = (DataGridRow)dg.ItemContainerGenerator.ContainerFromIndex(i);
			for (int j = 0; j < dg.Columns.Count; j++)
			{
				TextBlock cellContent = dg.Columns[j].GetCellContent(row) as TextBlock;
				var strContent = cellContent.Text;
				if (strContent == "BBB2")
				{
						// This if I want merely change the value (not my case)
						//cellContent.Text = "XXXX";
						//This if I want to put an image
						var dtgCell = cellContent.Parent as DataGridCell;
						dtgCell.Content = new Image() { Source = new BitmapImage(new Uri(@"C:\Users\Pictures\Ball_Red.png")) };
					}
				}
			}
		}
