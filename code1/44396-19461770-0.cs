    public string GenSQLCmd(string InSqlCmd, System.Data.Common.DbParameterCollection p) {
		foreach (System.Data.Common.DbParameter x in p) {
			InSqlCmd = InSqlCmd.Replace(x.ParameterName, "'" + x.Value.ToString() + "'");
		}
		return InSqlCmd;
	}
