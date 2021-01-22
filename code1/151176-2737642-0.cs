    for (int i = 0; i < 10; i++)
    {
        var panelTextBox = CreateBorderedTextBox();
        this.Controls.Add(panelTextBox);
    }
    private Panel CreateBorderedTextBox()
    {
        var panel = CreatePanel();
        var textBox = CreateTextBox();
        panel.Controls.Add(textBox);
        return panel;
    }
    private Panel CreatePanel()
    {
        var panel = new Panel();
        panel.Dock = DockStyle.Top;
        panel.Padding = new Padding(5);
        return panel;
    }
    private TextBox CreateTextBox()
    {
        var textBox = new TextBox();
        textBox.Multiline = true;
        textBox.Dock = DockStyle.Fill;
        return textBox;
    }
