    private void button1_Click(object sender, EventArgs e)
    {
        Form form = new Form() {
            Text = "My Dialog",
            Size = new Size(250, 80)
        };
        form.Controls.Add(new TextBox() {
            Font = this.Font,
            Text = "Test!",
            Size = new Size(150, this.Font.Height),
            Location = new Point(50, 10)
        });
        form.ShowDialog();
        form.Controls.OfType<TextBox>().First().Dispose();
        form.Dispose();
    }
