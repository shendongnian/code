    public Form1()
    {
        InitializeComponent();
        MydataGridView.CellFormatting += MydataGridView_CellFormatting;
    }
    private void MydataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
            if (e.ColumnIndex == 1) //Index of your DataGridViewComboBoxCell 
            {
                e.Value = "yourDefaultValue";
            }
    }
