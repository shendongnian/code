    private static void AddSqlCommand(StringBuilder sql, string[] columns, string[] types, string[] values, string table)
            {
                sql.AppendLine($"UPDATE {table}");
                sql.AppendLine("SET");
    
                //skip LoginId columns
                for (int i = 1; i < columns.Length; i++)
                {
                    switch (types[i].Trim())
                    {
                        case "int":
                            sql.Append($"   {columns[i].Trim()} = {values[i]}");
                            break;
    
                        default:
                            sql.Append($"   {columns[i].Trim()} = '{values[i]}'");
                            break;
                    }
    
                    if (columns.Length > 1 && i != columns.Length - 1)
                    {
                        sql.Append(",");
                    }
    
                    sql.AppendLine();
                }
    
                sql.AppendLine("WHERE");
                sql.AppendLine($"   ISNULL({columns[0].Trim()}, '') = '{values[0]}';");
                sql.AppendLine();
            }
    
        }
