    public void txtBox_OnTextChanged(object sender, EventArgs e)
    {
        var textBox = (TextBox)sender;
        OtherMethod(textBox.Name, "Some New Value");
    }
    public void OtherMethod(string name, string value)
    {
        // Do whatever here
    }
