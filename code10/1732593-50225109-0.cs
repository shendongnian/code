    try
    {
        Database1Entities database1Entities = new Database1Entities();
        //Edit the connectionString
    
        SqlConnection con = new SqlConnection(database1Entities.Database.Connection.ConnectionString);
        con.Open();
    
        //Changed values to be in correct order
        string q = "insert into videos(Upload_User, Title, Discription, Video_Time, Tags, [Format], Thumbnail_Path, Video_Path) " +
                            "values('" + user + "','" + Title.Text + "','" + DiscriptionTextBox.Text + "','" + time + "','" + TagsTextBox.Text + "','" + ext + "','" + thumbpathAccess + "','" + pathAccess + "')";
                        
        SqlCommand cmd = new SqlCommand(q, con);
        cmd.ExecuteNonQuery();
        
        //Save changes back to source
        database1Entities.SaveChanges();
        
        Response.Write("<script>alert('Data Saved!');</script>");
        con.Close();
    }
