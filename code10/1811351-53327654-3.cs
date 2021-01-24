    public void button1_Click(object sender, EventArgs e)
    {
        var button = new Button();
        Controls.Add(button);
        button.Click += Click;
    }
    public void Click(object sender, EventArgs e)
    {
        Button pressedButton = (Button) sender;
        ColorDialog dialog = new ColorDialog {Color = pressedButton.BackColor};
        if (dialog.ShowDialog() == DialogResult.OK)
        {
            pressedButton.BackColor = dialog.Color;
        }
    }
