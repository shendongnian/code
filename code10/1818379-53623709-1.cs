        private void button1_Click(object sender, EventArgs e)
        {
            var singleton = Singleton.Instance;
            var f = singleton.AdminForm; 
            f.Show(); 
        }
