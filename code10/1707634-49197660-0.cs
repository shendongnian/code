    if (dt.Rows.Count == 1)
                {
                    if (dt.Rows[0][0].ToString() == "Admin")
                    {
                        MessageBox.Show("You are granted with access.", "Welcome!");
                        this.Hide();
                        frmMain fma = new frmMain(dt.Rows[0][0].ToString());
                        fma.Closed += (s, args) => this.Close();
                        fma.Show();
                    }
                    else if (dt.Rows[0][0].ToString() == "User")
                    {
                        MessageBox.Show("You are granted with access.", "Welcome!");
                        this.Hide();
                        frmMain fma = new frmMain(dt.Rows[0][0].ToString());
                        fma.Closed += (s, args) => this.Close();
                        fma.Show();
                    }
                }
