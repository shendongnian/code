        //Program.cs:
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
        //MainForm.cs
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            if (login.ShowDialog() == DialogResult.OK)
            {
                //make assignments from login
                currentUser = login.User;
            }
            else
            {
                //take needed action
                Application.Exit();
                return;
            }
        }
