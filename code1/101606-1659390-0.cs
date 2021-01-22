    private BindingSource Source = new BindingSource();
    Form1_Load(object sender, EventArgs e)
    {
        // set Source's DataSource to your DataTable here.
        mainDataGridView.DataSource = source;
        // create DataGridView columns and their bindings here.
        Form2 f2 = new Form2();
        f2.TopMost = true;
        f2.Source = Source;
        f2.Show();
    }
