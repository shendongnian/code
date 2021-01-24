    public static class DesignerUtils
    {
    	public static string GetXamlPathFromActivityDesignerElement<TActivityDesigner
            (FrameworkElement element) where TActivityDesigner : ActivityDesigner
    	{
    		TActivityDesigner dataContext = element.DataContext as TActivityDesigner;
            EditingContext editingContext = dataContext.Context;
            ContextItemManager items = editingContext.Items;
            WorkflowFileItem fileItem = (WorkflowFileItem)items
                .SingleOrDefault(item => item is WorkflowFileItem);
    
    		return fileItem.LoadedFile;
    	}
    }
