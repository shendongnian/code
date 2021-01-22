    // in the parent form:
    public void ShowMyForm()
    {
        MyForm form = new MyForm();
        form.propertyA = ...;
        from.propertyB = ...;
        DialogResult dlgResult = form.ShowDialog(this);
        switch (dlgResult)
        {
            case System.Windows.Forms.DialogResult.Abort:
                ProcessFormNotLoaded();
                break;
            case System.Windows.Forms.DialogResult.OK:
                ProcessFormOk();
                break;
            // etc.
        }
    }
