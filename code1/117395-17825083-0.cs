    public static class ControlFinder<T>
    {
        public static IEnumerable<T> FindControl(DependencyObject root)
        {
            int count = VisualTreeHelper.GetChildrenCount(root);
            for (int i = 0; i < count; ++i)
            {
                dynamic child = VisualTreeHelper.GetChild(root, i);
                if (child is T)
                {
                    yield return (T)child;
                }
                else
                {
                    foreach (T found in FindMyCustControl(child))
                    {
                        yield return found;
                    }
                }
            }
        }
    }
