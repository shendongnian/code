    DependencyObject parent = ExVisualTreeHelper.FindVisualParent<UserControl>(this);
    public static class ExVisualTreeHelper
    {
        /// <summary>
        /// Finds the visual parent.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sender">The sender.</param>
        /// <returns></returns>
        public static T FindVisualParent<T>(DependencyObject sender) where T : DependencyObject
        {
            if (sender == null)
            {
                return (null);
            }
            else if (VisualTreeHelper.GetParent(sender) is T)
            {
                return (VisualTreeHelper.GetParent(sender) as T);
            }
            else
            {
                DependencyObject parent = VisualTreeHelper.GetParent(sender);
                return (FindVisualParent<T>(parent));
            }
        } 
    }
