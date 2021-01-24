    private Form1 _form;
    public MyForm(Form1 form)
    {
        _form = form;
    }
    private void button1_Click(object sender, EventArgs e)
    {
        _form.ChangeLabel();
    }
