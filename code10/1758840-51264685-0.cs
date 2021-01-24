    public static bool HasInvalidRows(DataGrid datagrid)
    {
    	var valid = true;
    	foreach (var item in datagrid.ItemContainerGenerator.Items)
    	{
    		var evaluateItem = datagrid.ItemContainerGenerator.ContainerFromItem(item);
    		if (evaluateItem == null) continue;
    
    		if (!(evaluateItem is DataGridRow dgr)) continue;
    
    		dgr.BindingGroup.CommitEdit();
    
    		valid &= !System.Windows.Controls.Validation.GetHasError(evaluateItem);
    	}
    
    	return !valid;
    }
