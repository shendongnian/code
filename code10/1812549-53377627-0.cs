    private void OnMenuSelected(object sender, CustomArgstype args)
    {
        var parameter = args.MenuName;
        if (parameter != null)
        {
            page = (Page)Activator.CreateInstance(type, parameter);
        }
        else
        {
            page = (Page)Activator.CreateInstance(type);
        }
    }
 
   
    
