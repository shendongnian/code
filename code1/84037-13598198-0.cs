    ResultSet set = s.getResultSet();
			ResultSetMetaData metaData = set.getMetaData();
			int totalColumn = metaData.getColumnCount();
			Object[] dataRow = new Object[totalColumn];
			if(set!= null)
			{
				for(int i=1;i<=totalColumn;i++)
				{
					table.addColumn(metaData.getColumnName(i));
				}
				while(set.next())
				{
					for(int i=1;i<=totalColumn;i++)
					{
						dataRow[i-1] = set.getObject(i);
					}
					table.addRow(dataRow);
				}
				
			}
