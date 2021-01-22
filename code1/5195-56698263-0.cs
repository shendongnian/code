        static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Form1 form1 = new Form1();
                form1.Visible = false;
                Application.Run();
           
            }
     private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
            {
                this.Close();
                Application.Exit();
            }
