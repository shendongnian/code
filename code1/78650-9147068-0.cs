    private void PopDataBaseName()
    {
        try
        {
            SqlCommand cmd = new SqlCommand("sp_generate_report", con);
            cmd.Parameters.Add("@TABLE_NAME", SqlDbType.VarChar,100).Value = TextBox1.Text;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);
        }
        catch (Exception ex)
        {
        }
    }
