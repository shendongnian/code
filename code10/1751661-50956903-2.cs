    List<string> photoNames = new List<string>();
    private void button1_Click(object sender, EventArgs e)
    {
        photoNames.Add("Ree");
        listBox1.DataSource = null;
        listBox1.DataSource = photoNames;                
    }
