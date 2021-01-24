    string cs = ConfigurationManager.ConnectionStrings["PRMSConnectionString"].ToString();
    SqlConnection con = new SqlConnection(cs);
    SqlTransaction objTransaction;
    bool flag = false;
    
    for (int i = 0; i < dgv_Purchase.Rows.Count - 1; i++)
    {
        con.Open();
        objTransaction = con.BeginTransaction();
        //**************************Command 1 Code*******************
        string query1 = "INSERT ......";
        SqlCommand cmd1 = new SqlCommand(query1, con, objTransaction);
    
        //***************************Command 2 Code*******************
        string query2 = "INSERT .....";
        SqlCommand cmd2 = new SqlCommand(query2, con, objTransaction);
        //****************************Command 3 Code*******************
        try
        {
            cmd1.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
			if (flag==false)
			{
				string query3 = "INSERT. ......";
				SqlCommand cmd3 = new SqlCommand(query3, con, objTransaction);
				cmd3.ExecuteNonQuery();
				flag = true;
			}
            objTransaction.Commit();
            lblSF.Text = "Success!";
        }
        catch (Exception ex)
        {
    
            MessageBox.Show("Exception " + ex);
            objTransaction.Rollback();
            lblSF.Text = "Failed!";
            return false;
        }
        finally
        {
            con.Close();
        }
    }
