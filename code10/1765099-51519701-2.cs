    private bool IsHighlighted()
    {
        return this.DataGridView.SelectionMode == DataGridViewSelectionMode.FullRowSelect && 
            this.DataGridView.CurrentCell != null && this.DataGridView.CurrentCell.Selected &&
            this.DataGridView.CurrentCell.OwningColumn == this.OwningColumn &&
            AccessibilityImprovements.Level2;
    }
