    public delegate void TextChangedEventHandler(object sender, EventArgs e);
    public event TextChangedEventHandler LabelTextChanged;
    
    // ...
    
    protected void MyTextBox_TextChanged(object sender, EventArgs e)
    {
        if (LabelTextChanged != null) {
            LabelTextChanged(this, e);
        }
    }
