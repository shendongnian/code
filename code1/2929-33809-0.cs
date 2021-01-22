		public void LoadProcedureInfo()
		{
			SqlConnection connection = new SqlConnection();
			ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["ConnectionString"];
			connection.ConnectionString = settings.ConnectionString;
			connection.Open();
			DataTable procedureDataTable = connection.GetSchema("Procedures");
			DataColumn procedureDataColumn = procedureDataTable.Columns["ROUTINE_NAME"];
			if (procedureDataColumn != null)
			{
				foreach (DataRow row in procedureDataTable.Rows)
				{
					String procedureName = row[procedureDataColumn].ToString();
					DataTable parmsDataTable = connection.GetSchema("ProcedureParameters", new string[] { null, null, procedureName });
					DataColumn parmNameDataColumn = parmsDataTable.Columns["PARAMETER_NAME"];
					DataColumn parmTypeDataColumn = parmsDataTable.Columns["DATA_TYPE"];
					foreach (DataRow parmRow in parmsDataTable.Rows)
					{
						string parmName = parmRow[parmNameDataColumn].ToString();
						string parmType = parmRow[parmTypeDataColumn].ToString();
					}
				}
			}
		}
