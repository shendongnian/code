    private IHierarchyData dataSource;
    private TreeView treeView;
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public IHierarchyData DataSource
    {
        get { return dataSource; }
        set
        {
            if (value != dataSource)
            {
                dataSource = value;
                nodeDictionary.Clear();
                UpdateRootNodes(treeView, value);
            }
        }
    }
    [Category("Behavior")]
    [DefaultValue(null)]
    [Description("Specifies the TreeView that the hierarchy should be bound to.")]
    public TreeView TreeView
    {
        get { return treeView; }
        set
        {
            if (value != treeView)
            {
                if (treeView != null)
                {
                    UnregisterEvents(treeView);
                }
                treeView = value;
                nodeDictionary.Clear();
                RegisterEvents(value);
                UpdateRootNodes(treeView, dataSource);
            }
        }
    }
