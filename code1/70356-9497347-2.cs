		public static string convertDataTableToString(DataTable dataTable)
		{
			string data = string.Empty;
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				DataRow row = dataTable.Rows[i];
				for (int j = 0; j < dataTable.Columns.Count; j++)
				{
					data += dataTable.Columns[j].ColumnName + "~" + row[j];
					if (j == dataTable.Columns.Count - 1)
					{
						if (i != (dataTable.Rows.Count - 1))
							data += "$";
					}
					else
						data += "|";
				}
			}
			return data;
		}
