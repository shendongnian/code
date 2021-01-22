    string text = String.Empty;
    if(textbox.Text.Contains(Environment.NewLine))
    {
        //textbox contains a new line, replace new lines with spaces
        text = textbox.Text.Replace(Environment.NewLine, " ");
    }
    else
    {
        //single line - simply assign to variable
        text = textbox.Text;
    }
