    public static class DesignerUtils
    {
    	public static string GetXamlPathFromActivityDesignerElement<TActivityDesigner
            (TActivityDesigner designer) where TActivityDesigner : ActivityDesigner
    	{
            EditingContext editingContext = designer.Context;
            ContextItemManager items = editingContext.Items;
            WorkflowFileItem fileItem = (WorkflowFileItem)items
                .SingleOrDefault(item => item is WorkflowFileItem);
    
    		return fileItem.LoadedFile;
    	}
    }
