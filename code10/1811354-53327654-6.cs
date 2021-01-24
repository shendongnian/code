    public void Click(object sender, EventArgs e)
    {
        Button pressedButton = (Button) sender;
        ColorDialog dialog = buttonDictionary[pressedButton];
        if (dialog == null)
        {
            dialog = new ColorDialog();
            buttonDictionary[pressedButton] = dialog;
        }
        if (dialog.ShowDialog() == DialogResult.OK)
        {
            pressedButton.BackColor = dialog.Color;
        }
    }
