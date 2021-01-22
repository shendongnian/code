    public static List<string> getKeyNames(String tableName, DbConnection conn)
		{
			var returnList = new List<string>();
	
			DataTable mySchema = (conn as OleDbConnection).
				GetOleDbSchemaTable(OleDbSchemaGuid.Primary_Keys,
				                    new Object[] {null, null, tableName});
			// following is a lengthy form of the number '3' :-)
			int columnOrdinalForName = mySchema.Columns["COLUMN_NAME"].Ordinal;
			foreach (DataRow r in mySchema.Rows)
			{
				returnList.Add(r.ItemArray[columnOrdinalForName].ToString());
			}
			return returnList;
		}
