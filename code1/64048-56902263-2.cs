    public static readonly DependencyProperty SelectedTreeViewItemProperty = DependencyProperty.Register("SelectedTreeViewItem", typeof(MyObject), typeof(MyViewModel), new PropertyMetadata(OnSelectedTreeViewItemChanged));
        private static void OnSelectedTreeViewItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as MyViewModel).OnSelectedTreeViewItemChanged(e);
        }
        private void OnSelectedTreeViewItemChanged(DependencyPropertyChangedEventArgs e)
        {
            //do your stuff here
        }
        public MyObject SelectedWorkOrderTreeViewItem
        {
            get { return (MyObject)GetValue(SelectedTreeViewItemProperty); }
            set { SetValue(SelectedTreeViewItemProperty, value); }
        }
