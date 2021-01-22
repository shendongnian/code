		public static String ParameterValueForSQL(this SqlParameter sp)
		{
			String retval = "";
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
					retval = "'" + sp.Value.ToString().Replace("'", "''") + "'";
					break;
				case SqlDbType.Bit:
					retval = (sp.Value.ToBooleanOrDefault(false)) ? "1" : "0";
					break;
				default:
					retval = sp.Value.ToString().Replace("'", "''");
					break;
			}
			return retval;
		}
		public static String CommandAsSql(this SqlCommand sc)
		{
			StringBuilder sql = new StringBuilder();
			Boolean FirstParam = true;
			sql.AppendLine("use " + sc.Connection.Database + ";");
			switch (sc.CommandType)
			{
				case CommandType.StoredProcedure:
					sql.AppendLine("declare @return_value int;");
					foreach (SqlParameter sp in sc.Parameters)
					{
						if ((sp.Direction == ParameterDirection.InputOutput) || (sp.Direction == ParameterDirection.Output))
						{
							sql.Append("declare " + sp.ParameterName + "\t" + sp.SqlDbType.ToString() + "\t= ");
							sql.AppendLine(((sp.Direction == ParameterDirection.Output) ? "null" : sp.ParameterValueForSQL()) + ";");
						}
					}
					sql.AppendLine("exec [" + sc.CommandText + "]");
					foreach (SqlParameter sp in sc.Parameters)
					{
						if (sp.Direction != ParameterDirection.ReturnValue)
						{
							sql.Append((FirstParam) ? "\t" : "\t, ");
							if (FirstParam) FirstParam = false;
							if (sp.Direction == ParameterDirection.Input)
								sql.AppendLine(sp.ParameterName + " = " + sp.ParameterValueForSQL());
							else
								sql.AppendLine(sp.ParameterName + " = " + sp.ParameterName + " output");
						}
					}
					sql.AppendLine(";");
					sql.AppendLine("select 'Return Value' = convert(varchar, @return_value);");
					foreach (SqlParameter sp in sc.Parameters)
					{
						if ((sp.Direction == ParameterDirection.InputOutput) || (sp.Direction == ParameterDirection.Output))
						{
							sql.AppendLine("select '" + sp.ParameterName + "' = convert(varchar, " + sp.ParameterName + ");");
						}
					}
					break;
				case CommandType.Text:
					sql.AppendLine(sc.CommandText);
					break;
			}
			return sql.ToString();
		}
