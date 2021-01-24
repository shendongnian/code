    SqlDataAdapter da;  
            DataSet ds = new DataSet();  
            StringBuilder htmlTable = new StringBuilder();  
      
            protected void Page_Load(object sender, EventArgs e)  
            {  
                if (!Page.IsPostBack)  
                    BindData();  
            }  
      
            private void BindData()  
            {  
                SqlConnection con = new SqlConnection();  
                con.ConnectionString = @"Data Source=MYPC\SqlServer2k8;Integrated Security=true;Initial Catalog=MyCompany";  
                SqlCommand cmd = new SqlCommand("SELECT * FROM Customer", con);  
                da = new SqlDataAdapter(cmd);  
                da.Fill(ds);  
                con.Open();  
                cmd.ExecuteNonQuery();  
                con.Close();  
      
                htmlTable.Append("<table border='1'>");  
                htmlTable.Append("<tr style='background-color:green; color: White;'><th>Customer ID.</th><th>Name</th><th>Address</th><th>Contact No</th></tr>");  
      
                if (!object.Equals(ds.Tables[0], null))  
                {  
                    if (ds.Tables[0].Rows.Count > 0)  
                    {  
      
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)  
                        {  
                            htmlTable.Append("<tr style='color: White;'>");  
                            htmlTable.Append("<td>" + ds.Tables[0].Rows[i]["Name"] + "</td>");  
                            htmlTable.Append("<td>" + ds.Tables[0].Rows[i]["Email"] + "</td>");  
                            htmlTable.Append("<td>" + ds.Tables[0].Rows[i]["Mobile"] + "</td>");  
                            htmlTable.Append("<td><a>Action</a></td>");  
                            htmlTable.Append("</tr>");  
                        }  
                        htmlTable.Append("</table>");  
                        DBDataPlaceHolder.Controls.Add(new Literal { Text = htmlTable.ToString() });  
                    }  
                    else  
                    {  
                        htmlTable.Append("<tr>");  
                        htmlTable.Append("<td align='center' colspan='4'>There is no Record.</td>");  
                        htmlTable.Append("</tr>");  
                    }  
                }  
            } 
