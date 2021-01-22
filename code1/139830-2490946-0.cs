    bool isKeyRepeating = false;
    public void textBox1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
    {
        if (isKeyRepeating)
        {
            e.SuppressKeyPress = true;
        }
        else
        {
            isKeyRepeating = true;
        }
        
    }
    public void textBox1_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
    {
        isKeyRepeating = false;
    }
