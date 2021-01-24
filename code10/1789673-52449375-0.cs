    conn.Open();
    DataSet ds = new DataSet();
    SqlDataAdapter da = new SqlDataAdapter(cmdStr, conn);
    da.SelectCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = Convert.ToInt32(TB_PatientID.Text);
    da.Fill(ds, "dsTable1");
