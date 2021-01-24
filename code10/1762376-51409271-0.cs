        public int GetActivityRowCount(DateTime fromDate, DateTime thruDate, string grpCds, string catCds, string typCds, long? memNbr, long? subNbr, string searchBy, string dispActivity, string statCds, bool showUncategorized, string debugYN)
        {
            using (var cmd = new OracleCommand("pack_SomePack.func_SearchRowCount", this.Connection))
            using (var result = new OracleParameter("result", OracleDbType.Int32, ParameterDirection.ReturnValue))
            using (var fromDateParam = new OracleParameter("in_FromDate", OracleDbType.Date, fromDate, ParameterDirection.Input))
            using (var thruDateParam = new OracleParameter("in_ThruDate", OracleDbType.Date, thruDate, ParameterDirection.Input))
            using (var grpCdsParam = new OracleParameter("in_GrpCds", OracleDbType.Varchar2, grpCds, ParameterDirection.Input))
            using (var catCdsParam = new OracleParameter("in_CatCds", OracleDbType.Varchar2, catCds, ParameterDirection.Input))
            using (var typCdsParam = new OracleParameter("in_TypCds", OracleDbType.Varchar2, typCds, ParameterDirection.Input))
            using (var memNbrParam = new OracleParameter("in_MemNbr", OracleDbType.Int64, memNbr, ParameterDirection.Input))
            using (var subNbrParam = new OracleParameter("in_SubNbr", OracleDbType.Int64, SubNbr, ParameterDirection.Input))
            using (var searchByParam = new OracleParameter("in_SearchBy", OracleDbType.Varchar2, searchBy, ParameterDirection.Input))
            using (var dispActivityParam = new OracleParameter("in_dispActivity", OracleDbType.Varchar2, dispActivity, ParameterDirection.Input))
            using (var statCdsParam = new OracleParameter("in_StatCds", OracleDbType.Varchar2, statCds, ParameterDirection.Input))
            using (var uncategorizedYnParam = new OracleParameter("in_UncategorizedYN", OracleDbType.Char, showUncategorized ? "Y" : "N", ParameterDirection.Input))
            using (var debugYnParam = new OracleParameter("in_DebugYN", OracleDbType.Char, debugYN, ParameterDirection.Input))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(result);
                cmd.Parameters.Add(fromDateParam);
                cmd.Parameters.Add(thruDateParam);
                cmd.Parameters.Add(grpCdsParam);
                cmd.Parameters.Add(catCdsParam);
                cmd.Parameters.Add(typCdsParam);
                cmd.Parameters.Add(memNbrParam);
                cmd.Parameters.Add(subNbrParam);
                cmd.Parameters.Add(searchByParam);
                cmd.Parameters.Add(dispActivityParam);
                cmd.Parameters.Add(statCdsParam);
                cmd.Parameters.Add(uncategorizedYnParam);
                cmd.Parameters.Add(debugYnParam);
                cmd.BindByName = true;
                cmd.ExecuteNonQuery();
                return Convert.ToInt32(result.Value);
            }
        }
