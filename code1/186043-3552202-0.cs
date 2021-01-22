    public string GetSomeValue()
    {
        var form = new F2();
        form.ShowDialog();
        return form.TextBox1.Text;
    }
