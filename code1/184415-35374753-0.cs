    private void Test(Form form)
    {
        Contract.Requires(Valid(form.Name));
        MessageBox.Show(form.Name);
    }
    [Pure]
    private bool Valid(string str)
    {
        return !string.IsNullOrEmpty(str);
    }
