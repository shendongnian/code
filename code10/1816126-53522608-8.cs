    public Form1()
    {
        InitializeComponent();
        MydataGridView.DefaultValuesNeeded += MydataGridView_DefaultValuesNeeded;
    }
    private void MydataGridView_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
    {
        e.Row.Cells[1].Value = "yourDefaultValue";
    }
