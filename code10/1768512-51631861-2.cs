    private int ButtonCount = 0;
    private int BtnY = 13;
    private void button1_Click(object sender, EventArgs e)
    {
        Button btn1 = new Button();
        btn1.Name = "btn" + ButtonCount;
        btn1.Click += new EventHandler(btn1_Click);
        btn1.Size = new Size(18, 18);
        btn1.Location = new Point(1, BtnY * ButtonCount);
        ButtonCount++;
        btn1.Text = "X";
        btn1.ForeColor = Color.Red;
        textBox1.Controls.Add(btn1);
        string sent = ("\t" + "Testline" + ButtonCount);
        textBox1.AppendText(sent);
        textBox1.AppendText(Environment.NewLine);
    }
    void btn1_Click(object sender, EventArgs e)
    {
        var bt = sender as Button;
        var btId = textBox1.Controls.IndexOf(bt);
        textBox1.Controls.Remove(bt);
        var lines = textBox1.Text.Replace("\r\n", "\n").Split('\n').ToList();
        lines.RemoveAt(btId);
        textBox1.Text = string.Join("\r\n", lines);
        foreach (Button btn in textBox1.Controls)
        {
            var Id = int.Parse(btn.Name.Replace("btn", ""));
            if (Id > btId)
            {
                var b = textBox1.Controls.Find(btn.Name, false)[0];
                var loc = btn.Location;
                b.Location = new Point(loc.X, loc.Y - BtnY);
            }
        }
        ButtonCount--;
    }
