    private void button1_Click(object sender, EventArgs e)
            {
                AddNewContol(new object[]{flowLayoutPanel1, CreateButton(DateTime.Now.Ticks.ToString())});
            }
    
            private void button2_Click(object sender, EventArgs e)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(AddNewContol), new object[] { flowLayoutPanel1, CreateButton(DateTime.Now.Ticks.ToString()) });
            }
