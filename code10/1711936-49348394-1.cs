       SqlConnection con = new SqlConnection("*****");
       SqlCommand cmd = new SqlCommand("********=@id", con);
       SqlParameter parId = new SqlParameter("@id", SqlDbType.Int);
       cmd.Parameters.Add(parId);
       SqlDataAdapter da = new SqlDataAdapter(cmd);
       DataSet ds = new DataSet();  
    
      foreach (int i in userdetails)
      {
          parId.Value = i;
          da.Fill(ds);       
      }
    
        gvSelected.Visible = true;
        gvSelected.DataSource = ds;
        gvSelected.DataBind();
