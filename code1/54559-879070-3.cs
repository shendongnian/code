     private void SessionChecker()
            {
                try
                {
                    check = new Timer();
                    check.Enabled = true;
                    check.Interval = 1000;
                    check.Tick += new EventHandler(check_Tick);
                }
                catch (Exception)
                {
                    
                    throw;
                }
                
            }
        void check_Tick(object sender, EventArgs e)
        {
            try
            {
                if (!usersession.SessionAlive)
                {
                    new LoginForm().ShowDialog();
                    check.Stop();
                    
                }
                    
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }
