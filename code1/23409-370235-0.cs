        private void Form1_Load(object sender, EventArgs e)
        {
            DialogResult result = showDialog();
            if (result == DialogResult.OK)
            {
                //Ok
            }
            else
            {
                DialogResult r = MessageBox.Show("Are you sure?", "Sure?", MessageBoxButtons.YesNo);
                if(r.ToString()=="No")
                {
                    showDialog();
                }
            }
        }
        public DialogResult showDialog()
        {
            SaveFileDialog savefileDialog1 = new SaveFileDialog();
            DialogResult result = savefileDialog1.ShowDialog();
            return result;
        }
