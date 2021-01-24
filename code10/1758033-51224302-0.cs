        protected void Button1_Click(object sender, EventArgs e)
        {
            string username = txtemail.Text;
            string password = txtpwd.Text;
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=TEAFAMILY;Initial Catalog=Bolsen;Integrated Security=True; MultipleActiveResultSets=true;"))
            {
                string query = "SELECT * FROM Customers WHERE cEmail = @Username and cPassword = @Password";
                SqlCommand cmd = new SqlCommand(query, sqlCon);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);
                sqlCon.Open();
                var result = cmd.ExecuteScalar();
                if (result != null)
                {
                    Session["sFlag"] = "T"; // sFlag = "T" means user has logged in
                    Session["sName"] = rdr["Firstname"];
                    Session["sEmail"] = rdr["cEmail"];
                    Session["sAddress"] = rdr["cCompanyAddress"];
                    Session["sEmail"] = rdr["cEmail"];
                    logoutbtn.Visible = true;
                    sqlCon.Close();
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    Session["sFlag"] = "F";
                    Session["sName"] = "";
                    Session["sUserId"] = "";
                    loginmessage.Text = "Error in login - Please login again   ";
                }
            }
        }
