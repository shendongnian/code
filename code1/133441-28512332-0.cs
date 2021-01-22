		private void InitToList() {
			Grid wp = new Grid();
			wp.Margin = new Thickness(0);
			wp.ColumnDefinitions.Add(new ColumnDefinition());
			wp.ColumnDefinitions.Add(new ColumnDefinition());
			wp.ColumnDefinitions.Add(new ColumnDefinition());
			wp.ColumnDefinitions.Add(new ColumnDefinition());
			wp.RowDefinitions.Add(new RowDefinition());  // adding this fixed the overlapping
			int curCol = 0;
			int curRow = 0;
			foreach (string name in toIds) {
				if (curCol >= wp.ColumnDefinitions.Count()) {
					wp.RowDefinitions.Add(new RowDefinition());
					curCol = 0;
					curRow++;
				}
				CheckBox cb = new CheckBox();
				cb.Name = String.Format("{0}Check", name.ToLower().Replace(" ", ""));
				cb.IsChecked = false;
				cb.Margin = new Thickness(5, 5, 5, 5);
				cb.Content = name;
				Grid.SetColumn(cb, curCol);
				Grid.SetRow(cb, curRow);
				wp.Children.Add(cb);
				curCol++;
			}
