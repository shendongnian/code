    public class NoScrollTreeView : TreeView
    {
        public class NoScrollTreeViewItem : TreeViewItem
        {
            public NoScrollTreeViewItem() : base()
            {
                this.RequestBringIntoView += delegate (object sender, RequestBringIntoViewEventArgs e) {
                    e.Handled = true;
                };
            }
            protected override DependencyObject GetContainerForItemOverride()
            {
                return new NoScrollTreeViewItem();
            }
        }
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new NoScrollTreeViewItem();
        }
    }
