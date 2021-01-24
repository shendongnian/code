        SqlConnection connsv = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        connsv.Open();
        string SelectQuery = @"UPDATE [Table_Name] SET 
                                [Service Start Time]=@servStartTime
                                WHERE [ID]=@shipnum";
        SqlCommand SelectCmd = new SqlCommand(SelectQuery, connsv);
        SelectCmd.Parameters.Add("@servStartTime", SqlDbType.DateTime).Value = txtSrvStartTime.Text;
        SelectCmd.ExecuteNonQuery();
        connsv.Close();
