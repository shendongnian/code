        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form2 login = new Form2();
            if (login.ShowDialog() == DialogResult.Yes)
            {
                Application.Run(new Form1());
            }
        }
