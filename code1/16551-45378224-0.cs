     public static string getQueryFromCommand(SqlCommand cmd)
        {
            StringBuilder CommandTxt = new StringBuilder();
            CommandTxt.Append("DECLARE ");
            List<string> paramlst = new List<string>();
            foreach (SqlParameter parms in cmd.Parameters)
            {
                paramlst.Add(parms.ParameterName);
                CommandTxt.Append(parms.ParameterName + " AS ");
                CommandTxt.Append(parms.SqlDbType.ToString());
                CommandTxt.Append(",");
            }
            if (CommandTxt.ToString().Substring(CommandTxt.Length-1, 1) == ",")
                CommandTxt.Remove(CommandTxt.Length-1, 1);
            CommandTxt.AppendLine();
            int rownr = 0;
            foreach (SqlParameter parms in cmd.Parameters)
            {
                string val = String.Empty;
                if (parms.DbType.Equals(DbType.String) || parms.DbType.Equals(DbType.DateTime))
                    val = "'" + Convert.ToString(parms.Value).Replace(@"\", @"\\").Replace("'", @"\'") + "'";
                if (parms.DbType.Equals(DbType.Int16) || parms.DbType.Equals(DbType.Int32) || parms.DbType.Equals(DbType.Int64) || parms.DbType.Equals(DbType.Decimal) || parms.DbType.Equals(DbType.Double))
                    val = Convert.ToString(parms.Value);
                CommandTxt.AppendLine();
                CommandTxt.Append("SET " + paramlst[rownr].ToString() + " = " + val.ToString());
                rownr += 1;
            }
            CommandTxt.AppendLine();
            CommandTxt.AppendLine();
            CommandTxt.Append(cmd.CommandText);
            return CommandTxt.ToString();
        }
