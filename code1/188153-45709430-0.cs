    private void UserControl_Loaded(object sender, RoutedEventArgs e)
    {
        var textBox = FindVisualChild<TextBox>(CodedCommentBox);
        textBox.Focus();
    }
    private TChildItem FindVisualChild<TChildItem>(DependencyObject obj) where TChildItem : DependencyObject
    {
        for (var i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
        {
            var child = VisualTreeHelper.GetChild(obj, i);
            var item = child as TChildItem;
            if (item != null)
            {
                return item;
            }
            var childOfChild = FindVisualChild<TChildItem>(child);
            if (childOfChild != null)
            {
                return childOfChild;
            }
        }
        return null;
    }
