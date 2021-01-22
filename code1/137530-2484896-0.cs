    public partial class TreeViewHierarchyBinding : Component
    {
        public TreeViewHierarchyBinding()
        {
            InitializeComponent();
        }
        public TreeViewHierarchyBinding(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }
    }
