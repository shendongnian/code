    public static string CreateTABLE(string tableName, DataTable table)
    {
        string sqlsc;
        sqlsc = "CREATE TABLE " + tableName + "(";
        for (int i = 0; i < table.Columns.Count; i++)
        {
            sqlsc += "\n [" + table.Columns[i].ColumnName + "] ";
            string columnType = table.Columns[i].DataType.ToString();
            switch (columnType)
            {
                case "System.Int32":
                    sqlsc += " int ";
                    break;
                case "System.Int64":
                    sqlsc += " bigint ";
                    break;
                case "System.Int16":
                    sqlsc += " tinyint ";
                    break;
                case "System.Decimal":
                    sqlsc += " decimal ";
                    break;
                case "System.DateTime":
                    sqlsc += " datetime ";
                    break;
                case "System.String":
                default:
                    sqlsc += string.Format(" nvarchar({0}) ", table.Columns[i].MaxLength == -1 ? "max" : table.Columns[i].MaxLength.ToString());
                    break;
            }
            if (table.Columns[i].AutoIncrement)
                sqlsc += " IDENTITY(" + table.Columns[i].AutoIncrementSeed.ToString() + "," + table.Columns[i].AutoIncrementStep.ToString() + ") ";
            if (!table.Columns[i].AllowDBNull)
                sqlsc += " NOT NULL ";
            sqlsc += ",";
        }
        return sqlsc.Substring(0,sqlsc.Length-1) + "\n)";
    }
