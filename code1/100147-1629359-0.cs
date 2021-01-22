        static void Main()
        {
            Form1 f1 = new Form1();
            DialogResult dr = f1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                Application.Run(new Form2());
            }
            else
            {
                Application.Exit();
            }
        }
