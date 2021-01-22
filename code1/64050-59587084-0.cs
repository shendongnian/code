    public class TreeViewEx : TreeView
    {
        public static readonly DependencyProperty SelectedItemExProperty = DependencyProperty.Register("SelectedItemEx", typeof(object), typeof(TreeViewEx), new FrameworkPropertyMetadata(default(object))
        {
            BindsTwoWayByDefault = true // Required in order to avoid setting the "BindingMode" from the XAML
        });
        public object SelectedItemEx
        {
            get => GetValue(SelectedItemExProperty);
            set => SetValue(SelectedItemExProperty, value);
        }
        protected override void OnSelectedItemChanged(RoutedPropertyChangedEventArgs<object> e)
        {
            SelectedItemEx = e.NewValue;
        }
    }
