        static System.Data.DataTable DtTbl (System.Data.DataTable[] dtToJoin)
        {
            System.Data.DataTable dtJoined = new System.Data.DataTable();
            foreach (System.Data.DataColumn dc in dtToJoin[0].Columns)
                dtJoined.Columns.Add(dc.ColumnName);
            foreach (System.Data.DataTable dt in dtToJoin)
                foreach (System.Data.DataRow dr1 in dt.Rows)
                {
                    System.Data.DataRow dr = dtJoined.NewRow();
                    foreach (System.Data.DataColumn dc in dtToJoin[0].Columns)
                        dr[dc.ColumnName] = dr1[dc.ColumnName];
                    dtJoined.Rows.Add(dr);
                }
            return dtJoined;
        }
