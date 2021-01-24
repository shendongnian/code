    txtPassword.TextMode = TextBoxMode.Password;
        }
      You need to change the TextBox mode for one of the conditions 
    // I think you need to set break points and check if this line is being triggered
    TextBox1.TextMode = TextBoxMode.SingleLine;
    // you can try this code which works fine. Add a button, and a textbox and set its textmode to Password. Type something the then click the button. 
    protected void Button1_Click1(object sender, EventArgs e)
    {
        TextBox1.TextMode = TextBoxMode.SingleLine;
    }
