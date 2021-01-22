        private void ExtractSqlCommandForDebugging(SqlCommand cmd)
        {
            string sql = "exec " + cmd.CommandText;
            bool first = true;
            foreach (SqlParameter p in cmd.Parameters)
            {
                string value = ((p.Value == DBNull.Value) ? "null"
                                : (p.Value is string) ? "'" + p.Value + "'"
                                : p.Value.ToString());
                if (first)
                {
                    sql += string.Format(" {0}={1}", p.ParameterName, value);
                    first = false;
                }
                else
                {
                    sql += string.Format("\n , {0}={1}", p.ParameterName, value);
                }
            }
            sql += "\nGO";
            Debug.WriteLine(sql);
        }
