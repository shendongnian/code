    using (SqlConnection con = new SqlConnection("conection string")) {
    	using (SqlCommand cmd2 = new SqlCommand("UPDATE sumant SET email=@Email WHERE code = @Code", con)) {
    		cmd2.Parameters.AddWithValue("@Email", email);
    		cmd2.Parameters.AddWithValue("@Code", textBox2.Text);
    		con.Open();
    		cmd2.ExecuteNonQuery();
    	}
    }
