    private void textBoxX1_KeyDown(object sender, KeyEventArgs e)
    {
        sqlcon.Close();
        sqlcon.Open();
    
        if (e.KeyCode == Keys.Enter)
        {
    		try{
    			string t = lbl_Time.Text;
    			string d = lbl_Date.Text;
    
    			string selectQueryName = "SELECT name FROM tbl_attendanceMembers where memberCode=" + "'" + textBoxX1.Text + "'";
    			var sqlcmdName = new SqlCommand(selectQueryName, sqlcon);
    			var resultName = sqlcmdName.ExecuteScalar();
    			if (resultName != DBNull.Value)
    			{
    				string selectQueryId = "SELECT MAX(id) FROM tbl_attendanceSheet";
    				var sqlcmdId = new SqlCommand(selectQueryId, sqlcon);
    				var resultId = sqlcmdId.ExecuteScalar();
    
    				if (resultId != DBNull.Value)
    				{
    					string selectQueryCockin = "SELECT Clockin FROM tbl_attendanceSheet where id=" + "resultId";
    					var sqlcmdCockin = new SqlCommand(selectQueryCockin, sqlcon);
    					var resultCockin = sqlcmdId.ExecuteScalar();
    
    					if (resultCockin != DBNull.Value
    					{
    						this.lbl_mmbrname.Text = resultName.ToString();
    						this.lbl_timestored.Text = t;
    						textBoxX1.Clear();  
    					}
    				}
    			}
    			else //if result id == null
    			{
    				sqlcon.Open();
    				SqlCommand sqlcmdClockin = new SqlCommand("InputClockIn", sqlcon);
    				sqlcmdClockin.CommandType = CommandType.StoredProcedure;
    				sqlcmdClockin.Parameters.AddWithValue("@InputDate", d);
    				sqlcmdClockin.Parameters.AddWithValue("@InputTime", t);
    				sqlcmdClockin.ExecuteNonQuery();
    				SqlDataAdapter sqlda = new SqlDataAdapter("SELECT * FROM tbl_attendanceMembers", sqlcon);
    				DataTable dt = new DataTable();
    				sqlda.Fill(dt);
    				dataGridView1.DataSource = dt;
    			}
    		} catch (Exception ex) {
    			//Do somethging with the exception if desired
    		} finally {
    			sqlcon.Close();
    		}
        }
    }
