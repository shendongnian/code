        protected void btnDoSomething_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid)
            return;
        //Do something
    }
    protected void TextBoxValidate(object source, ServerValidateEventArgs args)
    {
        args.IsValid = (args.Value != null && args.Value != "0");
    }
