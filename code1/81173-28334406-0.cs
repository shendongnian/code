		for (int i = 0; i < dg.Items.Count; i++)
		{
			DataGridRow row = (DataGridRow)dg.ItemContainerGenerator.ContainerFromIndex(i);
				for (int j = 0; j < dg.Columns.Count; j++)
				{
					TextBlock cellContent = dg.Columns[j].GetCellContent(row) as TextBlock;
					Console.WriteLine(cellContent.Text);
				}
		}
