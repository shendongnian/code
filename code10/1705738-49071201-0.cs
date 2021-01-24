          protected void Filterbtn_Click(object sender, EventArgs e)
                {
                    string commandFilterUsers = "SELECT DISTINCT " + ddlFilterUsers.SelectedValue + " FROM UsersDB";
                    string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        SqlCommand sqlCommand = new SqlCommand(commandFilterUsers, connection);
                        SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                        adapter.Fill(dataset, "FillUser");
                    }
                    ddlShowResult.DataTextField = dataset.Tables["FillUser"].Columns[1].ToString();//User Name: Will be shown to user
                    ddlShowResult.DataValueField = dataset.Tables["FillUser"].Columns[0].ToString();//User ID: will be used in backend
                    ddlShowResult.DataSource = dt;
                    ddlShowResult.DataBind();
                }
