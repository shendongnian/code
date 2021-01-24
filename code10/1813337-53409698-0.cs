        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
          Application.SetCompatibleTextRenderingDefault(false);
          Application.Run(new Form1());
           while (true)
           {
                Form1 frm = new Form1();
                frm.Show();
           }
        }
