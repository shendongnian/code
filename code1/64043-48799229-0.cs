    // the Type CustomThing needs to implement IsSelected with notification
    // for this to work.
    public class CustomTreeView : TreeView
    {
        public CustomThing SelectedCustomThing
        {
            get
            {
                return (CustomThing)GetValue(SelectedNode_Property);
            }
            set
            {
                SetValue(SelectedNode_Property, value);
                if(value != null) value.IsSelected = true;
            }
        }
        public static DependencyProperty SelectedNode_Property =
            DependencyProperty.Register(
                "SelectedCustomThing",
                typeof(CustomThing),
                typeof(CustomTreeView),
                new FrameworkPropertyMetadata(
                    null,
                    FrameworkPropertyMetadataOptions.None,
                    SelectedNodeChanged));
        public CustomTreeView(): base()
        {
            this.SelectedItemChanged += new RoutedPropertyChangedEventHandler<object>(SelectedItemChanged_CustomHandler);
        }
        void SelectedItemChanged_CustomHandler(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            SetValue(SelectedNode_Property, SelectedItem);
        }
        private static void SelectedNodeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var treeView = d as CustomTreeView;
            var newNode = e.NewValue as CustomThing;
            treeView.SelectedCustomThing = (CustomThing)e.NewValue;
        }
    }
