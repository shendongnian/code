    [STAThread]
        static void Main()
        {
            if (PriorProcess() != null)
            {
                
                MessageBox.Show("Another instance of the app is already running.");
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form());
        }
