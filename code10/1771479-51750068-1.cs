    var connString = "Host=localhost;Username=postgres;Password=123;Database=postgres";
    using (var conn = new NpgsqlConnection(connString))
    {
        conn.Open();
        string checkuser = "select password, role from Login where name=@username";
        using (var com = new NpgsqlCommand(checkuser, conn))
        {
            com.Parameters.AddWithValue("@username", TextBoxUserName.Text);
            using (var reader = com.ExecuteReader())
            {
                if (reader.Read())
                {
                    string password = reader["password"].ToString();
                    LoginRole role = (LoginRole)reader["role"];
                    if (password == TextBoxPassword.Text)
                    {
                        Session["New"] = TextBoxUserName.Text;
                        switch (role)
                        {
                            case LoginRole.User:
                                Response.Redirect("user.aspx");
                                break;
                            case LoginRole.Admin:
                                Response.Redirect("MainForm.aspx");
                                break;
                            case LoginRole.Director:
                                Response.Redirect("director.aspx");
                                break;
                        }
                    }
                    else
                        Response.Write("Password is  NOT correct !");
                }
                else
                    Response.Write("Username is  NOT correct !");
            }
        }
    }
