    public string ParameterValueForSQL(SqlParameter sp)
        {
            string retval = "";
            switch (sp.SqlDbType)
            {
                case SqlDbType.Char:
                case SqlDbType.NChar:
                case SqlDbType.NText:
                case SqlDbType.NVarChar:
                case SqlDbType.Text:
                case SqlDbType.Time:
                case SqlDbType.VarChar:
                case SqlDbType.Xml:
                case SqlDbType.Date:
                case SqlDbType.DateTime:
                case SqlDbType.DateTime2:
                case SqlDbType.DateTimeOffset:
                    if (sp.Value == DBNull.Value)
                    {
                        retval = "NULL";
                    }
                    else
                    {
                        retval = "'" + sp.Value.ToString().Replace("'", "''") + "'";
                    }
                    break;
                case SqlDbType.Bit:
                    if (sp.Value == DBNull.Value)
                    {
                        retval = "NULL";
                    }
                    else
                    {
                        retval = ((bool)sp.Value == false) ? "0" : "1";
                    }
                    break;
                default:
                    if (sp.Value == DBNull.Value)
                    {
                        retval = "NULL";
                    }
                    else
                    {
                        retval = sp.Value.ToString().Replace("'", "''");
                    }
                    break;
            }
            return retval;
        }
        public string CommandAsSql(SqlCommand sc)
        {
            string sql = sc.CommandText;
            sql = sql.Replace("\r\n", "").Replace("\r", "").Replace("\n", "");
            sql = System.Text.RegularExpressions.Regex.Replace(sql, @"\s+", " ");
            foreach (SqlParameter sp in sc.Parameters)
            {
                string spName = sp.ParameterName;
                string spValue = ParameterValueForSQL(sp);
                sql = sql.Replace(spName, spValue);
            }
            sql = sql.Replace("= NULL", "IS NULL");
            sql = sql.Replace("!= NULL", "IS NOT NULL");
            return sql;
        }
