        private void button2_Click(object sender, EventArgs e)
        {
            if (cbofilter.SelectedIndex == 0)
            {
                string sql;
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = "Server= " + Environment.MachineName.ToString() + @"\; Initial Catalog=TEST;Integrated Security = true";
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds1 = new DataSet();
                ds1 = DBConn.getStudentDetails("sp_RetrieveSTUDNO");
                sql = "Select * from Test where STUDNO like '" + txtvalue.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                da.SelectCommand = cmd;
                da.Fill(ds1);
                dbgStudentDetails.DataSource = ds1;
                dbgStudentDetails.DataMember = ds1.Tables[0].TableName;
                dbgStudentDetails.Refresh();
             
            }
            else if (cbofilter.SelectedIndex == 1)
            {
                //string sql;
                //SqlConnection conn = new SqlConnection();
                //conn.ConnectionString = "Server= " + Environment.MachineName.ToString() + @"\; Initial Catalog=TEST;Integrated Security = true";
                
                //SqlDataAdapter da = new SqlDataAdapter();
                //DataSet ds1 = new DataSet();
                //ds1 = DBConn.getStudentDetails("sp_RetrieveSTUDNO");
                //sql = "Select * from Test where Name like '" + txtvalue.Text + "'";
                //SqlCommand cmd = new SqlCommand(sql,conn);
                //cmd.CommandType = CommandType.Text;
                //da.SelectCommand = cmd;
                //da.Fill(ds1);
               // dbgStudentDetails.DataSource = ds1;
                //dbgStudentDetails.DataMember = ds1.Tables[0].TableName;
                //ds.Tables[0].DefaultView.RowFilter = "Studno = + txtvalue.text + "; 
                dbgStudentDetails.DataSource = ds.Tables[0];
                dbgStudentDetails.Refresh();
            }
            
