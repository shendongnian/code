    private void button1_Click(object sender, EventArgs e)
    {
        var labelNames = Enumerable.Range(1, 250).Select(num => "l" + num.ToString());
        var myLabels = from labelName in labelNames
                        join label in this.Controls.OfType<Label>()
                        on labelName equals label.Name
                        select label;
        StringBuilder builder = new StringBuilder();
        foreach (Label label in myLabels)
        {
            builder.Append(label.Text);
        }
        string output = builder.ToString();
        MessageBox.Show(output);
    }
    private void Form1_Load(object sender, EventArgs e)
    {
        for (int i = 1; i <= 250; i++)
        {
            Label label = new Label();
            label.Name = "l" + i.ToString();
            label.Text = "_" + i.ToString();
            this.Controls.Add(label);
        }
    }
