    private void CommitRowItem()
    {
    	if (IsEditingRowItem)
    	{
    		EditableItems.CommitEdit();
    	}
    	else
    	{
    		EditableItems.CommitNew();
    
    		// Show the placeholder again
    		UpdateNewItemPlaceholder(/* isAddingNewItem = */ false);
    	}
    }
