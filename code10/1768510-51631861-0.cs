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
        ButtonCount--;
        var bt = sender as Button;
        textBox1.Controls.Remove(bt);
        var index = textBox1.Text.LastIndexOf(Environment.NewLine);
        textBox1.Text = textBox1.Text.Remove(index);
        index = textBox1.Text.LastIndexOf(Environment.NewLine);
        if (index == -1)
        {
            textBox1.Text = "";
            return;
        }
        textBox1.Text = textBox1.Text.Remove(index);
        textBox1.AppendText("\r\n");
    }
