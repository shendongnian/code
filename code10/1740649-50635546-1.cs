    public class CardTemplateSelector: DataTemplateSelector
    {
        public DataTemplate TreeViewItemDataTemplate { get; set; }
        public DataTemplate TreeViewObjDataTemplate { get; set; }
        protected override DataTemplate SelectTemplateCore(object item)
        {
            TreeViewNode treeViewNode = item as TreeViewNode;
            if (treeViewNode.Content is StorageFolder|| treeViewNode.Content is StorageFile)
            {
                return TreeViewItemDataTemplate;
            }
            if (treeViewNode.Content is Test)
            {
                return TreeViewObjDataTemplate;
            }
            return base.SelectTemplateCore(item);
        }
        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            return SelectTemplateCore(item);
        }
    }
