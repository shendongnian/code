    // in the parent form:
    public void ShowMyForm()
    {
        MyForm form = new MyForm();
        form.propertyA = ...;
        from.propertyB = ...;
        DialogResult dlgResult = form.ShowDialog(this);
        switch (dlgResult)
        {
            case System.Windows.Forms.DialogResult.Cancel:
                ...
                break;
            case System.Windows.Forms.DialogResult.OK:
                ...
                break;
            // etc.
        }
    }
