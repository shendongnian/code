    public Form1()
    {
        InitializeComponent();
        checkedListBox1.Items.Add("Can't check me", CheckState.Indeterminate);
    }
    private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
    {
        if (e.CurrentValue == CheckState.Indeterminate)
        {
            e.NewValue = CheckState.Indeterminate;
        }
    }
