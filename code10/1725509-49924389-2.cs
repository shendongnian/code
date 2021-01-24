    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        CustomValidator1.Validate();
    }
    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
    ///do the validation here return true if passes else false.
        args.IsValid = false;
    }
