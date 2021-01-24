    private void Window_ContentRendered(object sender, EventArgs e)
	{
		_innerGrid = UIHelper.FindVisualChild<Grid>(dataGrid);
		item2Column.MinWidth = _item2MinViewableWidth;
		item1Column.Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
		item2Column.Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
		MaxWidth = ActualWidth;
		_innerGrid.MinWidth = item1Column.ActualWidth + _item2MinViewableWidth;
		_innerGrid.Width = item1Column.ActualWidth + _item2MinViewableWidth;
		UpdateLayout();
		var mainGridInitWidth = mainGrid.ActualWidth;
		MinWidth = ActualWidth;
		_innerGrid.Width = Double.NaN;
		mainGrid.Width = mainGridInitWidth;
	}
	private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
	{
		if (e.WidthChanged && _innerGrid != null)
		{
			var widthDetla = e.NewSize.Width - e.PreviousSize.Width;
			mainGrid.Width += widthDetla;
		}
		if (Math.Abs(ActualWidth - MaxWidth) < 1)
		{
			dataGrid.HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden;
		}
		else
		{
			dataGrid.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
		}
	}
