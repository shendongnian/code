    public static SimpleCommand ButtonClickedCommand { get; set; }
    static CommandClass()
    {
        ButtonClickedCommand = new SimpleCommand
                               {
                                   ExecuteDelegate =
                                   x=> ButtonClicked(x as WorkItemTypeMappings)
                               };
    }
    public static ButtonClicked(WorkItemTypeMappings mappings)
    {
        if(mappings != null) MessageBox.Show(mapping.PercentMapped)
    }
