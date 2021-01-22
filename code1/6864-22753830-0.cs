        private void button1_Click(object sender, EventArgs e)
        {
            getAvailableRAM();
        }
        public void getAvailableRAM()
        {
            ComputerInfo CI = new ComputerInfo();
            ulong mem = ulong.Parse(CI.TotalPhysicalMemory.ToString());
            richTextBox1.Text = (mem / (1024*1024) + " MB").ToString();
        }
