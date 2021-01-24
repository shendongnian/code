    private void Page_Load(object sender, EventArgs e)
    {
    	checkedListBox1.Items.Add("Sunday", CheckState.Checked);
    	checkedListBox1.Items.Add("Monday", CheckState.Unchecked);
    	checkedListBox1.Items.Add("Tuesday", CheckState.Indeterminate);
    	checkedListBox1.Items.Add("Wednesday", CheckState.Checked);
    	checkedListBox1.Items.Add("Thursday", CheckState.Unchecked);
    	checkedListBox1.Items.Add("Friday", CheckState.Indeterminate);
    	checkedListBox1.Items.Add("Saturday", CheckState.Indeterminate);
    }
