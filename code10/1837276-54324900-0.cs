    public int LoginUser(LoginViewmodel userLogin)
        {
                var cmdCommand = "select userIdColumnName from users WHERE loginUsername=@LOGINUSER AND loginPassword=@LOGINPASS;";
                OpenConnection();
                MySqlCommand loginCommand = new MySqlCommand(cmdCommand, studentsConnection);
                loginCommand.Parameters.AddWithValue("@LOGINUSER", userLogin.LoginUsername);
                loginCommand.Parameters.AddWithValue("@LOGINPASS", userLogin.LoginPassword);
                var test = Convert.ToInt32(loginCommand.ExecuteScalar());
                userLogin.Id = test;
                Console.WriteLine(userLogin.Id);
                CloseConnection();
                if (test > 0)
                {
                    return test;
                }
                else
                {
                    return 0
                }
            }
