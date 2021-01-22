    SqlConnection con = new SqlConnection("Your connection string");
    con.Open();
    SqlCommand cmd = new SqlCommand(TexdtBox1.Text, con);
    cmd.ExecuteNonQuery();
    con.Close()
