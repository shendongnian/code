    private List<Keys> pressedKeys = new List<Keys>();
    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
        pressedKeys.Add(e.KeyCode);
        printPressedKeys();
    }
    private void Form1_KeyUp(object sender, KeyEventArgs e)
    {
        pressedKeys.Remove(e.KeyCode);
        printPressedKeys();
    }
    private void printPressedKeys()
    {
        label1.Text = string.Empty;
        foreach (var key in pressedKeys)
        {
            label1.Text += key.ToString() + Environment.NewLine;
        }
    }
