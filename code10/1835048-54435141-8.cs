    	private void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
		{
			ResizeColumns(true);
		}
		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			this.SizeToContent = SizeToContent.Manual;
			item2Column.MinWidth = item2MinViewableWidth;
			item1Column.Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
			item2Column.Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
			this.MinWidth = item1Column.ActualWidth + item2MinViewableWidth;
			this.Width = this.MinWidth;
			ResizeColumns();
		}
		private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
		{
			SetWindowProperties();
		}
	
