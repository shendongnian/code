    public static class DependencyObjectExtensions
    {
        public static T FindAncestor<T>(this DependencyObject obj) where T : DependencyObject
        {
            return obj.FindAncestor(typeof(T)) as T;
        }
        public static DependencyObject FindAncestor(this DependencyObject obj, Type ancestorType)
        {
            var tmp = VisualTreeHelper.GetParent(obj);
            while (tmp != null && !ancestorType.IsAssignableFrom(tmp.GetType()))
            {
                tmp = VisualTreeHelper.GetParent(tmp);
            }
            return tmp;
        }
    }
