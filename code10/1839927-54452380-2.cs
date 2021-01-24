    private void button1_Click(object sender, EventArgs e)
    {
        ShowMyDialog("Dialog Title", "Test!");
    }
    private void ShowMyDialog(string title, string text)
    {
        Form form = new Form()
        {
            Text = title,
            Size = new Size(250, 80)
        };
        form.Controls.Add(new TextBox()
        {
            Font = this.Font,
            Text = text,
            Size = new Size(150, this.Font.Height),
            Location = new Point(50, 10)
        });
        form.ShowDialog();
        form.Controls.OfType<TextBox>().First().Dispose();
        form.Dispose();
    }
