    static public class ControlAux
    {
        static public IEnumerable<T> GetVisualDescendants<T>(this DependencyObject item) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(item); ++i)
            {
                DependencyObject child = VisualTreeHelper.GetChild(item, i);
                if (typeof(T) == (child.GetType()))
                {
                    yield return (T)child;
                }
                foreach (T descendant in GetVisualDescendants<T>(child))
                {
                    yield return descendant;
                }
            }
        }
        static public T GetVisualDescendant<T>(this DependencyObject item, string descendantName) where T : DependencyObject
        {
            return
                GetVisualDescendants<T>(item).Where(
                descendant =>
                {
                    var frameworkElement = descendant as FrameworkElement;
                    return frameworkElement != null ? frameworkElement.Name == descendantName : false;
                }).
                FirstOrDefault();
        }
    }
