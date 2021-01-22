    private void ntfIcon_MouseClick(object sender, MouseEventArgs e)
            {
                if (e.Button==MouseButtons.Left)
                {
                    if (this.WindowState == FormWindowState.Minimized)
                    {
                        this.Show();
                        this.WindowState = FormWindowState.Normal;
                    }
                    else
                    {
                        this.WindowState = FormWindowState.Minimized;
                        this.Hide();
                    }
                }
            }
