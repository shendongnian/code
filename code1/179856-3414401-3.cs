        #region Grouping by Teamlead
        DataTable dtGroup = new DataTable();
        dtGroup = dtResult.Clone();
        foreach (DataColumn dc in dtResult.Columns)
        {
            dc.DataType = typeof(string);
        }
        dtGroup.AcceptChanges();
        foreach (string s in srLead)
        {
            string name = s;
            DataTable dtsource = new DataTable();
            dtsource = TeamLeadFilter(dtResult, name);
            CombineDatatable(ref dtGroup, dtsource);
            dtGroup.AcceptChanges();
        }
        #endregion
        #region TeamLeadFilter
        public DataTable TeamLeadFilter(DataTable dtResult, string str)
        {
            DataView dvData = new DataView(dtResult);
            dvData.RowFilter = "TeamLead ='" + str + "'";
            return dvData.ToTable();
        }
        #endregion
        #region CombineDatatable
        public DataTable CombineDatatable(ref DataTable destini, DataTable source)
        {
            foreach (DataRow dr in source.Rows)
            {
                destini.ImportRow(dr);
            }
            return destini;
        }
        #endregion  
