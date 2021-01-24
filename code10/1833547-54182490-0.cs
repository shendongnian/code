    private T FindVisualChild<T>(Visual visual) where T : Visual
    {
        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(visual); i++)
        {
            Visual child = (Visual)VisualTreeHelper.GetChild(visual, i);
            if (child != null)
            {
                T correctlyTyped = child as T;
                if (correctlyTyped != null)
                {
                    return correctlyTyped;
                }
                T descendent = FindVisualChild<T>(child);
                if (descendent != null)
                {
                    return descendent;
                }
            }
        }
        return null;
    }
