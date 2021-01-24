            public async Task GetAccounts()
        {
            MainWin w = new MainWin();
            await Task.Run(() =>
            {
    
                this.Dispatcher.Invoke(() =>
                {
                    using (SqlConnection connection = new SqlConnection(PublicVar.ConnectionString))
                    {
                        gymEntities2 database = new gymEntities2();
                        SqlConnection con1 = new SqlConnection(PublicVar.ConnectionString);
                        PublicVar.TodayTime = String.Format("{0:yyyy/MM/dd}", Convert.ToDateTime(TimeNow.Text));
                        con1.Open();
                        SqlCommand Actives = new SqlCommand("Select DISTINCT (LockEndDate) from LockTable Where Username = '" + txt_username.Text + "' and Password = '" + txt_password.Password + "'", con1);
                        object Active = Actives.ExecuteScalar();
                        string SystemActive = Convert.ToString(Active);
                        //   SqlCommand Commandcmds = new SqlCommand("update VW_TimeOut set UserActive = 2 where UserEndDate < '" + String.Format("{0:yyyy/MM/dd}", Convert.ToDateTime(TimeNow.Text)) + "'", con1);
                        //   Commandcmds.ExecuteScalar();
                        SqlCommand Commandcmd = new SqlCommand("SELECT COUNT(*) FROM LockTable Where Username = '" + txt_username.Text + "' and Password = '" + txt_password.Password + "' and LockEndDate between '" + String.Format("{0:yyyy/MM/dd}", Convert.ToDateTime(Lock.Text)) + "' And '" + SystemActive + "'", con1);
                        int userCount = (int)Commandcmd.ExecuteScalar();
                        //Find Gym ID -> To Set Public Value Strings
                        SqlCommand FindGymID = new SqlCommand("Select DISTINCT (LockID) from LockTable Where Username = '" + txt_username.Text + "' and Password = '" + txt_password.Password + "'", con1);
                        object ObGymID = FindGymID.ExecuteScalar();
                        if (userCount > 0)
                        {
                            try
                            {
                                RegistryKey UsernameKey = Registry.CurrentUser.CreateSubKey("SOFTWARE\\GYM");
                                if (CheakRem.IsChecked == true)
                                    if ((string)UsernameKey.GetValue("UserNameRegister") != "")
                                    {
                                        UsernameKey.SetValue("UserNameRegister", txt_username.Text.Trim());
                                        UsernameKey.SetValue("PasswordRegister", Module.Decode.EncryptTextUsingUTF8(txt_password.Password.Trim()));
                                    }
                                PublicVar.GymID = Convert.ToString(ObGymID);
                                login = true;
                            }
                            catch
                            {
                       
                                w.Username = null;
                                w.Password = null;
                            }
                        }
                        else
                        {
                            ErrorPage pageerror = new ErrorPage();
                            pageerror.Show();
                            con1.Close();
                            w.Username = null;
                            w.Password = null;
                        }
                        con1.Close();
                    }
                });
            });
            if (login == true)
            {
                w.Username = txt_username.Text;
                w.Password = txt_password.Password;
                w.Show();
                this.Close();
            }
        }
        #endregion
