    /// <summary>
    /// ListBoxItem Behavior class
    /// </summary>
    public static class ListBoxItemBehavior
    {
        #region IsBroughtIntoViewWhenSelected
        /// <summary>
        /// Gets the IsBroughtIntoViewWhenSelected value
        /// </summary>
        /// <param name="listBoxItem"></param>
        /// <returns></returns>
        public static bool GetIsBroughtIntoViewWhenSelected(ListBoxItem listBoxItem)
        {
            return (bool)listBoxItem.GetValue(IsBroughtIntoViewWhenSelectedProperty);
        }
        /// <summary>
        /// Sets the IsBroughtIntoViewWhenSelected value
        /// </summary>
        /// <param name="listBoxItem"></param>
        /// <param name="value"></param>
        public static void SetIsBroughtIntoViewWhenSelected(
          ListBoxItem listBoxItem, bool value)
        {
            listBoxItem.SetValue(IsBroughtIntoViewWhenSelectedProperty, value);
        }
        /// <summary>
        /// Determins if the ListBoxItem is bought into view when enabled
        /// </summary>
        public static readonly DependencyProperty IsBroughtIntoViewWhenSelectedProperty =
            DependencyProperty.RegisterAttached(
            "IsBroughtIntoViewWhenSelected",
            typeof(bool),
            typeof(ListBoxItemBehavior),
            new UIPropertyMetadata(false, OnIsBroughtIntoViewWhenSelectedChanged));
        /// <summary>
        /// Action to take when item is brought into view
        /// </summary>
        /// <param name="depObj"></param>
        /// <param name="e"></param>
        static void OnIsBroughtIntoViewWhenSelectedChanged(
          DependencyObject depObj, DependencyPropertyChangedEventArgs e)
        {
            ListBoxItem item = depObj as ListBoxItem;
            if (item == null)
                return;
            if (e.NewValue is bool == false)
                return;
            if ((bool)e.NewValue)
                item.Selected += OnListBoxItemSelected;
            else
                item.Selected -= OnListBoxItemSelected;
        }
        static void OnListBoxItemSelected(object sender, RoutedEventArgs e)
        {
            // Only react to the Selected event raised by the ListBoxItem 
            // whose IsSelected property was modified.  Ignore all ancestors 
            // who are merely reporting that a descendant's Selected fired. 
            if (!Object.ReferenceEquals(sender, e.OriginalSource))
                return;
            ListBoxItem item = e.OriginalSource as ListBoxItem;
            if (item != null)
                item.BringIntoView();
        }
        #endregion // IsBroughtIntoViewWhenSelected
    }
