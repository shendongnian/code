    private void frmControlPanel_Load(object sender, EventArgs e)
    
    {
                WindowState = FormWindowState.Maximized;
                
               ShowLogin();
               //User = "GutierrezDev"; // Get user name.
               //tssObject02.Text = User;
    }
    
     private void ShowLogin()
            {
                Login = new frmLogin
                            {
                                MdiParent = this,
                                Text = "Login",
                                MaximizeBox = false,
                                MinimizeBox = false,
                                FormBorderStyle = FormBorderStyle.FixedDialog,
                                StartPosition = FormStartPosition.CenterScreen
    
                            };
                Login.ShowDialog();
    
            }
