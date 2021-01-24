    private int ButtonCount = 0;
    private void button1_Click(object sender, EventArgs e)
    {
        Button btn1 = new Button();
        btn1.Name = "btn" + ButtonCount;
        btn1.Click += new EventHandler(btn1_Click);
        btn1.Size = new Size(18, 18);
        btn1.Location = new Point(1, 13 * ButtonCount);
        ButtonCount++;
        btn1.Text = "X";
        btn1.ForeColor = Color.Red;
        textBox1.Controls.Add(btn1);
        string sent = ("\t" + "Testline1");
        textBox1.AppendText(sent);
        textBox1.AppendText(Environment.NewLine);
    }
    void btn1_Click(object sender, EventArgs e)
    {
        var bt = sender as Button;
        textBox1.Controls.Remove(bt);
        var btId = int.Parse(bt.Name.Replace("btn", ""));
        var lines = textBox1.Text.Replace("\r\n", "\n").Split('\n');
        lines[btId] = "\t";
        textBox1.Text = string.Join("\r\n", lines);
    }
