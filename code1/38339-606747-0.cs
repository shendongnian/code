        private void button1_Click(object sender, EventArgs e)
        {
            new System.Threading.Thread(new System.Threading.ThreadStart(Run)).Start();
        }
        void Run()
        {
            label1.Invoke(new Action(delegate()
            {
                label1.Text = System.Threading.Thread.CurrentThread.Name + " " + System.DateTime.Now.ToString();
            }));
        }
