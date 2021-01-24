    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader dr;
    //some methods, fields
    private void btn_search_Click(object sender, EventArgs e)
    {
        con.Open();
        // as it has benn already said, you have to prevent yourself from SQL injection!
        cmd = (new SqlCommand("select * from TICKETSALES where REFERENCE=@ref", con)).Parameters.AddWithValue("@res", txtSearch.Text.Trim());
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            txtTrans.Text = dr.GetInt32("TRANSACTIONNUMBER").ToString();
            txtPax.Text = dr.GetString("PASSENGERNAME");
        }
        else
        {
            MessageBox.Show("Ticket Number not Found");
        }
    }
    // it looks like you have unamanaged resources held by fields in your form,
    // so to release them you have to call their Dispose() method!
    // normally you should use using keyword if they were used locally in a method, as other answer states
    public void Dispose()
    {
        base.Dispose();
        if (con != null) con.Dispose();
        if (cmd != null) cmd.Dispose();
        if (dr != null) dr.Dispose();
    }
