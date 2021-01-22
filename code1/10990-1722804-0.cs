    public class TreeViewItemBehaviour
    {
        #region IsBroughtIntoViewWhenSelected
        public static bool GetIsBroughtIntoViewWhenSelected(TreeViewItem treeViewItem)
        {
            return (bool)treeViewItem.GetValue(IsBroughtIntoViewWhenSelectedProperty);
        }
        public static void SetIsBroughtIntoViewWhenSelected(
          TreeViewItem treeViewItem, bool value)
        {
            treeViewItem.SetValue(IsBroughtIntoViewWhenSelectedProperty, value);
        }
        public static readonly DependencyProperty IsBroughtIntoViewWhenSelectedProperty =
            DependencyProperty.RegisterAttached(
            "IsBroughtIntoViewWhenSelected",
            typeof(bool),
            typeof(TreeViewItemBehaviour),
            new UIPropertyMetadata(false, OnIsBroughtIntoViewWhenSelectedChanged));
        static void OnIsBroughtIntoViewWhenSelectedChanged(
          DependencyObject depObj, DependencyPropertyChangedEventArgs e)
        {
            TreeViewItem item = depObj as TreeViewItem;
            if (item == null)
                return;
            if (e.NewValue is bool == false)
                return;
            if ((bool)e.NewValue)
            {
                item.Loaded += item_Loaded;
            }
            else
            {
                item.Loaded -= item_Loaded;
            }
        }
        static void item_Loaded(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = e.OriginalSource as TreeViewItem;
            if (item != null)
                item.BringIntoView();
        }
        #endregion // IsBroughtIntoViewWhenSelected
    }
