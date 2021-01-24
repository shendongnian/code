    public partial class CustomTreeView : UserControl
    {
        public CustomTreeView()
        {
            InitializeComponent();
        }
        #region SelectedItem Property
        public Node SelectedItem
        {
            get { return (Node)GetValue(SelectedProperty); }
            set { SetValue(SelectedProperty, value); }
        }
        public static readonly DependencyProperty SelectedProperty =
            DependencyProperty.Register(nameof(SelectedItem), typeof(Node), typeof(CustomTreeView),
                new FrameworkPropertyMetadata(null,
                                              FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                                              Selected_PropertyChanged)
                { DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged });
        protected static void Selected_PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as CustomTreeView).OnSelectedChanged(e.OldValue);
        }
        private void OnSelectedChanged(object oldValue)
        {
            if (SelectedItem != treeView.SelectedItem)
            {
                var tvi = treeView.ItemContainerGenerator.ContainerFromItem(SelectedItem) as TreeViewItem;
                if (tvi != null)
                {
                    tvi.IsSelected = true;
                }
            }
        }
        #endregion SelectedItem Property
        private void treeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (SelectedItem != e.NewValue)
            {
                SelectedItem = e.NewValue as Node;
            }
        }
    }
