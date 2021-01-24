    try
    {
        using(var con = new SqlConnection(conString))
        using(var cmd = new SqlCommand("insert into adjustments_config(document_number)values(@docNumber)", con)
        {
            con.Open();
            cmd.Parameters.AddWithValue("@docNumber", TextBoxDocNo.Text);
            var rowsAffected = cmd.ExecuteNonQuery();
        
            // ..validate rows affected
            Response.Redirect("About.aspx");
        }
    }
    catch(SqlException ex)
    {
        MessageBox.Show(ex.Message);
    }
