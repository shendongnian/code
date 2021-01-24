    Control focusedC;
    
    //Enter event handler for your TextBox
    
    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        focusedC = sender as TextBox;
    }
    
    //Click event handler 
    private void  button14_Click(object sender, EventArgs e)
    {
        if (focusedC != null)
        {
            focusedC.Focus();
            SendKeys.Send("Q");
        }
    }
