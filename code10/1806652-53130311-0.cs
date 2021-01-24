        #region LoginMethod
        bool login = false;
        public async Task PopulateMethodAsync()
        {
            var isLoginSuccess = await GetAccounts(txt_username.Text.Trim(), txt_password.password.Text.Trim(), Lock.Text.Trim(), TimeNow.Text.Trim());
            MainWin w = new MainWin();
            if (login == true)
            {
                w.Username = txt_username.Text;
                w.Password = txt_password.Password;
                w.Show();
                this.Close();
            }
            else
            {
                w.Username = null;
                w.Password = null;
            }
        }
        public async Task<bool> GetAccounts(string txt_username, string txt_password, string Lock, string TimeNow)
        {
            await Task.Run(() =>
            {
                using (SqlConnection connection = new SqlConnection(PublicVar.ConnectionString))
                {
                    gymEntities2 database = new gymEntities2();
                    SqlConnection con1 = new SqlConnection(PublicVar.ConnectionString);
                    PublicVar.TodayTime = String.Format("{0:yyyy/MM/dd}", Convert.ToDateTime(TimeNow));
                    con1.Open();
                    SqlCommand Actives = new SqlCommand("Select DISTINCT (LockEndDate) from LockTable Where Username = '" + txt_username + "' and Password = '" + txt_password + "'", con1);
                    object Active = Actives.ExecuteScalar();
                    string SystemActive = Convert.ToString(Active);
                    //   SqlCommand Commandcmds = new SqlCommand("update VW_TimeOut set UserActive = 2 where UserEndDate < '" + String.Format("{0:yyyy/MM/dd}", Convert.ToDateTime(TimeNow.Text)) + "'", con1);
                    //   Commandcmds.ExecuteScalar();
                    SqlCommand Commandcmd = new SqlCommand("SELECT COUNT(*) FROM LockTable Where Username = '" + txt_username + "' and Password = '" + txt_password + "' and LockEndDate between '" + String.Format("{0:yyyy/MM/dd}", Convert.ToDateTime(Lock)) + "' And '" + SystemActive + "'", con1);
                    int userCount = (int)Commandcmd.ExecuteScalar();
                    //Find Gym ID -> To Set Public Value Strings
                    SqlCommand FindGymID = new SqlCommand("Select DISTINCT (LockID) from LockTable Where Username = '" + txt_username + "' and Password = '" + txt_password + "'", con1);
                    object ObGymID = FindGymID.ExecuteScalar();
                    if (userCount > 0)
                    {
                        try
                        {
                            RegistryKey UsernameKey = Registry.CurrentUser.CreateSubKey("SOFTWARE\\GYM");
                            if (CheakRem.IsChecked == true)
                                if ((string)UsernameKey.GetValue("UserNameRegister") != "")
                                {
                                    UsernameKey.SetValue("UserNameRegister", txt_username);
                                    UsernameKey.SetValue("PasswordRegister", Module.Decode.EncryptTextUsingUTF8(txt_password));
                                }
                            PublicVar.GymID = Convert.ToString(ObGymID);
                            con1.Close();
                            return true;
                        }
                        catch
                        {
                        }
                    }
                    con1.Close();
                }
            });
            return false;
        }
        #endregion
        private async void btn_join_Click(object sender, RoutedEventArgs e)
        {
            await PopulateMethodAsync();
        }
