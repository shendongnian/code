     public bool LoginUser(LoginViewmodel userLogin, out string UserId)
            {
                var cmdCommand = "select count(1) from users WHERE loginUsername=@LOGINUSER AND loginPassword=@LOGINPASS;";
                OpenConnection();
                MySqlDataAdapter dtReader = new MySqlDataAdapter(cmdCommand, con);
                dtReader.SelectCommand.Parameters.AddWithValue("@LOGINUSER", userLogin.LoginUsername);
                dtReader.SelectCommand.Parameters.AddWithValue("@LOGINPASS", userLogin.LoginPassword);
                DataTable dt = new DataTable();
                dtReader.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    UserId = dt.Rows[0]["Id"].ToString();
                    return true;
                }
                else
                {
                    throw new BadLoginCredentialsException();
                }
            }
