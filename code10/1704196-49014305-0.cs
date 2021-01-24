    private void Form1_Load(object sender, EventArgs e)
    {
        listBox1.Items.Add(new { Id = "123456", Text = "123456 - Hello World 1!" });
        listBox1.Items.Add(new { Id = "7891011", Text = "123456 - Hello World 2!" });
        listBox1.DisplayMember = "Text";
    }
    private void button1_Click(object sender, EventArgs e)
    {
        foreach (dynamic item in listBox1.SelectedItems)
        {
            MessageBox.Show(item.Id);
        }
    }
