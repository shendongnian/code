		public static string convertDataTableToString(DataTable dataTable)
		{
			string data = string.Empty;
			int rowsCount = dataTable.Rows.Count;
			for (int i = 0; i < rowsCount; i++)
			{
				DataRow row = dataTable.Rows[i];
				int columnsCount = dataTable.Columns.Count;
				for (int j = 0; j < columnsCount; j++)
				{
					data += dataTable.Columns[j].ColumnName + "~" + row[j];
					if (j == columnsCount - 1)
					{
						if (i != (rowsCount - 1))
							data += "$";
					}
					else
						data += "|";
				}
			}
			return data;
		}
