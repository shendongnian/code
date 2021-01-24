                    MySqlDataReader myReader = cmd.ExecuteReader();
                    string user1 = "";
                    string pass1 = "";
                    bool stopLoop = false;
                    while (stopLoop == false && myReader.Read())
                    {
                        user1 = myReader[1].ToString(); //datacolumn -> user_login
                        pass1 = myReader[2].ToString(); //datacolumn -> user_pass
                        if ((user1 == txtUsername.Text) && (pass1 == txtPassword.Text))
                        {
                            stopLoop = true;
                            //rest of the true if code
                            
                            // If you didnt use a stopLoop flag you could have inserted here a break;
                        }
                        else
                        {
                            // your else code
                        }
                    }
                    myReader.Close();
