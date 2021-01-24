    public static Dictionary<string, List<Version>> AppVer()
	{
		Dictionary<string, List<Version>> versions = null;
		string SQL = "SELECT column1, column2 FROM myTable a LEFT JOIN myTable2 v ON v.ID_FK = a.ID_PK";
		var dt = new DataTable();
		try
		{
			using (var conn = new OracleConnection(conn_string))
			using (var da = new OracleDataAdapter(SQL, conn))
			{
				da.Fill(dt);
			}
			versions = dt.AsEnumerable()
				.GroupBy(r => r.Field<string>(0))
				.ToDictionary(
                    g => g.Key, 
                    g => g.Select(r => Version.Parse(r.Field<string>(1))).ToList());
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
		return versions;
	}
