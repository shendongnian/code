    private void numberButton_Click(object sender, EventArgs e)
    {
       checkifequa();
       var numButton = sender as Button;
       if(numButton != null)
          textBox1.Text = textBox1.Text + numButton.Text; // supposing your num buttons have only the number as text (otherwise you could use the Tag property of buttons)
    }
    
    private void operatorButton_Click(object sender, EventArgs e)
    {
       checkifequa();
       var operatorButton = sender as Button;
       if(operatorButton != null)
          textBox1.Text = textBox1.Text + operatorButton .Text; // supposing your operator buttons have only the operator as text (otherwise you could use the Tag property of button)
    }
    // ...
