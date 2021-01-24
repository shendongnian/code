			var groupBox1 = new GroupBox();
			this.thePanel.Children.Add(groupBox1);
			var groupBox2 = new GroupBox();
			var dataGrid = new DataGrid();
			dataGrid.Columns.Add(new DataGridTextColumn { Header = "Column1" });
			dataGrid.Columns.Add(new DataGridTextColumn { Header = "Column2" });
			dataGrid.Columns.Add(new DataGridTextColumn { Header = "Column3" });
			groupBox2.Content = dataGrid;
			this.thePanel.Children.Add(groupBox2);
