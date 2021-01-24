    private void DoAutoGeneratingColumn(object sender, System.Windows.Controls.DataGridAutoGeneratingColumnEventArgs e)
    {
        System.Windows.Controls.DataGridBoundColumn textCol = e.Column as System.Windows.Controls.DataGridBoundColumn;
        if (textCol != null)
        {
            textCol.Binding.TargetNullValue = string.Empty;
        }
    }
