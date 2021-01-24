    public static void OrderTreeSetup(ObservableCollection<tblProject> table,
        ListSortDirection direction)
    {
        ConfigureSorting(table, direction);
        foreach (tblProject project in table)
        {
            ConfigureSorting(project.tblLines, direction);
            foreach (tblLine line in project.tblLines)
            {
                //...etc...
            }
        }
    }
