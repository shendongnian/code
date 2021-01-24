    public DATEaSet GetDATEa()
    {
        string connStr = ConfigurationManager.ConnectionStrings["connstr"].ToString();
        string cmdStr = @"SELECT  SEQ,
										   ID,
										   DATE,
										   Started,
										   END,
										   TYPE,
										   ENTRANCE,
										   OUTGOING
								   FROM LOGING
							WHERE SICK_ID=@ID;";
        SqlConnection conn = new SqlConnection(connStr);
        using (SqlCommand cmd = new SqlCommand(cmdStr, conn))
        {
            try
            {
                conn.Open();
                cmd.CommandText = cmdStr;
                cmd.CommandType = CommandType.Text;
                ds = new DATEaSet();
                cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = Convert.ToInt32(TB_ID.Text);
                da = new SqlDATEaAdapter(cmd);
                da.Fill(ds, "DATEaTable1");
                MyDGV.Columns["MyDGV_RowNum"].DATEaPropertyName = ds.Tables["DATEaTable1"].Columns["SEQ"].ColumnName;
                MyDGV.Columns["MyDGV_SessionID"].DATEaPropertyName = ds.Tables["DATEaTable1"].Columns["ID"].ColumnName;
                MyDGV.Columns["MyDGV_DATEe"].DATEaPropertyName = ds.Tables["DATEaTable1"].Columns["DATE"].ColumnName;
                MyDGV.Columns["MyDGV_StartTime"].DATEaPropertyName = ds.Tables["DATEaTable1"].Columns["Started"].ColumnName;
                MyDGV.Columns["MyDGV_EndTime"].DATEaPropertyName = ds.Tables["DATEaTable1"].Columns["END"].ColumnName;
                MyDGV.Columns["MyDGV_Type"].DATEaPropertyName = ds.Tables["DATEaTable1"].Columns["TYPE"].ColumnName;
                MyDGV.Columns["MyDGV_CreatedBy"].DATEaPropertyName = ds.Tables["DATEaTable1"].Columns["ENTRANCE"].ColumnName;
                MyDGV.Columns["MyDGV_EntryDATEe"].DATEaPropertyName = ds.Tables["DATEaTable1"].Columns["OUTGOING"].ColumnName;
                return ds;
            }
            catch (Exception ex)
            {
                string ErrorMsg = ex.Message.Substring(0, Math.Min(ex.Message.Length, 1024));
                MessageBox.Show(ErrorMsg);
                return null;
            }
        }
    }
