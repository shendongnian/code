    private DataGridViewComboBoxColumn CreateComboBoxColumn(string colHeaderText, List<string> items)
    {
        var colOutcome = new DataGridViewComboBoxColumn(); 
        colOutcome.HeaderText = colHeaderText; 
        colOutcome.Width = 90; 
        colOutcome.Items.AddRange(items.ToArray());
        colOutcome.Name = String.Format("col{0}", colHeaderText);
        return colOutcome;   
    }
