    public static void FindVisualChildren<T>(this ICollection<T> children, DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                var brethren = LogicalTreeHelper.GetChildren(depObj);
                var brethrenOfType = LogicalTreeHelper.GetChildren(depObj).OfType<T>();
                foreach (var childOfType in brethrenOfType)
                {
                    children.Add(childOfType);
                }
                foreach (var rawChild in brethren)
                {
                    if (rawChild is DependencyObject)
                    {
                        var child = rawChild as DependencyObject;
                        FindVisualChildren<T>(children, child);
                    }
                }
            }
        }
