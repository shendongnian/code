    protected void InsertData1(object sender, EventArgs e)
     {
     try
      {
        foreach (GridViewRow gvRow in GridView1.Rows)
        {
            con = new  SqlConnection    
             (ConfigurationManager.ConnectionStrings["LocalSqlserver"].ConnectionString);
  
  
 
            TextBox t1 = (TextBox)GridView1.FooterRow.FindControl("TextBox2");
            TextBox t2 = (TextBox)GridView1.FooterRow.FindControl("TextBox4");
            TextBox t3 = (TextBox)GridView1.FooterRow.FindControl("TextBox6");
            TextBox t4 = (TextBox)GridView1.FooterRow.FindControl("TextBox8");
            TextBox t5 = (TextBox)GridView1.FooterRow.FindControl("TextBox10");
            TextBox t6 = (TextBox)GridView1.FooterRow.FindControl("TextBox12");
            cmd = new SqlCommand("insert into tblHelpDesk 
            (Name,Purpose,ContactNo,AlternativeNo,Email,Address) 
            values(@Name,@Purpose,@ContactNo,@AlternativeNo,@Email,@Address)", 
             con);
            con.Open();
            cmd.Parameters.AddWithValue("@Name", t1.Text);
            cmd.Parameters.AddWithValue("@Purpose", t2.Text);
            cmd.Parameters.AddWithValue("@ContactNo", t3.Text);
            cmd.Parameters.AddWithValue("@AlternativeNo", t4.Text);
            cmd.Parameters.AddWithValue("@Email", t5.Text);
            cmd.Parameters.AddWithValue("@Address", t6.Text);
            cmd.ExecuteNonQuery();
           
        }
      Page.Response.Redirect(Page.Request.Url.ToString(), true);
     }
    catch (Exception ex)
     { }
   }
