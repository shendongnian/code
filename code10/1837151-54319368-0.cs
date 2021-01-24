    private void submitBtn_Click(object sender, EventArgs e)
        {
            
            string a = "Accept";
            string b = "Reject";
            string queryUpdate1 = "";
            string queryUpdate2 = "";
            int row = DGVLeaves.CurrentCell.RowIndex;
            if (accptBtn.Checked)
            {
                if (type_rdonly.Text == "SL")
                {
                    if (ifEmployeeExist(con, emptime_rdonly.Text))
                    {
                        queryUpdate1 = @"UPDATE [LEAVE_EMP] SET EMP_STATUS ='" + a + "'WHERE [EMP_TIME] ='" + emptime_rdonly.Text + "'";
                    }
                    queryUpdate2 = "UPDATE LEAVE_ADMIN SET L_SPENT_SL = (L_SPENT_SL + 1), L_REM_SL = (L_REM_SL - 1)";
                }
                if (type_rdonly.Text == "VL")
                {
                    if (ifEmployeeExist(con, emptime_rdonly.Text))
                    {
                        queryUpdate1 = @"UPDATE [LEAVE_EMP] SET EMP_STATUS ='" + a + "'WHERE [EMP_TIME] ='" + emptime_rdonly.Text + "'";
                    }
                    queryUpdate2 = "UPDATE LEAVE_ADMIN SET L_SPENT_VL = (L_SPENT_VL + 1),L_REM_VL = (L_REM_VL - 1)";
                }
            }
            else if (rejBtn.Checked)
            {
                if (ifEmployeeExist(con, emptime_rdonly.Text))
                {
                    queryUpdate1 = @"UPDATE [LEAVE_EMP] SET EMP_STATUS ='" + b + "'WHERE [EMP_TIME] ='" + emptime_rdonly.Text + "'";
                }
            }
            con.Open();
            SqlCommand cmd = new SqlCommand() { Connection = con, CommandType = System.Data.CommandType.Text };
            if (!string.IsNullOrEmpty(queryUpdate1)) {
                cmd.CommandText = queryUpdate1;
                cmd.ExecuteNonQuery();
            }
            if (!string.IsNullOrEmpty(queryUpdate2))
            {
                cmd.CommandText = queryUpdate2;
                cmd.ExecuteNonQuery();
            }
            if (string.IsNullOrEmpty(queryUpdate1) && string.IsNullOrEmpty(queryUpdate2))
            {
                MessageBox.Show("Empty query");
            }
            con.Close();
        }
