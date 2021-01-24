    private void dataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
    {
    	var tb = e.EditingElement as TextBox;
    	var bindingIsDirty = tb.GetBindingExpression(TextBox.TextProperty).IsDirty;
    	buttonSave.IsEnabled |= (bindingIsDirty && e.EditAction == DataGridEditAction.Commit);
    }
