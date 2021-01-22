    private IEnumerable<MyCustControl> FindMyCustControl(DependencyObject root)
    {
        int count = VisualTreeHelper.GetChildrenCount(root);
        for (int i = 0; i < count; ++i)
        {
            DependencyObject child = VisualTreeHelper.GetChild(root, i);
            if (child is MyCustControl)
            {
                yield return (MyCustControl)child;
            }
            else
            {
                foreach (MyCustControl found in FindMyCustControl(child))
                {
                    yield return found;
                }
            }
        }
    }
