    private Form MyForm = null;
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        this.MyForm = this.FindForm();
        this.MyForm.FormClosing += this.OnFormClosing;
    }
    private void OnFormClosing(object sender, FormClosingEventArgs e)
    {
        Console.WriteLine("My Form is closing!");
        string myNumber = txMyNumber.Text;
    }
