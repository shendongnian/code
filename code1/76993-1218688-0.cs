    [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            bool exit = false;
            while (true)
            {
                if (exit) break;
                using (Form1 frm = new Form1())
                {
                    switch(frm.ShowDialog())
                    {
                        case DialogResult.OK:
                            break;
                        default:
                            exit = true;
                            break;
                    }   
                }
                if(exit) break;
                using (Form2 frm = new Form2())
                {
                    switch(frm.ShowDialog())
                    {
                        case DialogResult.OK:
                            break;
                        default:
                            exit = true;
                            break;
                    } 
                }
            }
        }
