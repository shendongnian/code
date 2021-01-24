    	private void ResizeColumns(bool dataIsEdited = false)
		{
			item1Column.Width = new DataGridLength(0);
			item2Column.Width = new DataGridLength(0);
			item1Column.Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
			item2Column.Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
			// For some reason, when a change in the cell contents causes the column to shrink,
			// the column's ActualWidth property does not update quickly enough. As a result,
			// the Window.MinWidth property was not being adjusted until the next change.
			// This resolves that. However, you do not want to run it for any of the other
			// events that trigger this method due to threading issues/priorities, so I
			// wrapped it in this bool parameter. It would be great if anyone has a better
			// alternative.
			if (dataIsEdited)
			{
				Dispatcher.Invoke(new Action(() => { }), DispatcherPriority.ContextIdle, null);
			}
			this.MinWidth = item1Column.ActualWidth + item2MinViewableWidth;
			var columnsWidthSum = item1Column.ActualWidth + item2Column.ActualWidth;
			this.MaxWidth = columnsWidthSum + windowWidthBuffer;
			SetWindowProperties();
		}
		private void SetWindowProperties()
		{
			// This is to deal with the precision issue for triggering the horizontal scroll bar.
			// The default behavior generated a condition where the scroll bar always was present
			// even when it wasn't necessary.
			if (Math.Abs(this.ActualWidth - this.MaxWidth) < 1)
			{
				dataGrid.HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden;
			}
			else
			{
				dataGrid.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
			}
		}
