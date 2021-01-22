            if(column.IsPrimaryKey)
            {
                sb.Append(" NOT NULL PRIMARY KEY");
                if(column.IsNumeric)
                    sb.Append(" AUTOINCREMENT ");
            }
