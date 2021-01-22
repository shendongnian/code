		private void GridDataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
		{
			DataGridView grid = sender as DataGridView;
			if (grid == null)
			{
				return;
			}
			DataTable dt = grid.DataSource as DataTable;
			if (dt == null)
			{
				return;
			}
			string nullText = _settings.NullText;
			string dateTimeFormat = _settings.DateTimeFormat;
			for (int i = 0; i < dt.Columns.Count; i++)
			{
				if (dt.Columns[i].DataType == typeof (DateTime))
				{
					DataGridViewCellStyle dateCellStyle = new DataGridViewCellStyle();
					dateCellStyle.NullValue = nullText;
					dateCellStyle.Format = dateTimeFormat;
					grid.Columns[i].DefaultCellStyle = dateCellStyle;
				}
			}
		}
