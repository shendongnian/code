    private void productsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        var field = typeof(DataGridViewComboBoxCell).GetField("mouseInDropDownButtonBounds",
            System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);
        var mouseInDropDownButtonBounds = field.GetValue(null);
    }
