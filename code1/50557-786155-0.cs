     private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                ListViewItem lvi = new ListViewItem("Test");
                listView1.Items.Add(lvi);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            listView1.CheckBoxes = false;
        }
