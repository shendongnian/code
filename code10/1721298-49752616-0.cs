    List<string> list = new List<string>();
    private void Form1_Load(object sender, EventArgs e)
    {
        list.AddRange(new string[] { "a", "b", "c" });
        comboBox1.Items.AddRange(list.ToArray());
        comboBox2.Items.AddRange(list.ToArray());
        comboBox3.Items.AddRange(list.ToArray());
    }
