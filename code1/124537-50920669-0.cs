    private bool isFirstTimeEntering;
    private void textBox_Enter(object sender, EventArgs e)
    {
        isFirstTimeEntering = true;
    }
    private void textBox_Click(object sender, EventArgs e)
    {
        switch (isFirstTimeEntering)
        {
            case true:
                isFirstTimeEntering = false;
                break;
            case false:
                return;
        }
        
        textBox.SelectAll();
        textBox.SelectionStart = 0;
        textBox.SelectionLength = textBox.Text.Length;
    }
