            if (row.Table.Columns.Contains(columnName))
            {
                if (row[columnName] == DBNull.Value)
                {
                    if (row.Table.Columns[columnName].DataType.IsValueType)
                    {
                        return Activator.CreateInstance(row.Table.Columns[columnName].DataType);
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return row[columnName];
                }
            }
            return null;
        }
