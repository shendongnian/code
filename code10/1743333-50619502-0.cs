        private T FindChildControl<T>(DependencyObject control, string ctrlName) 
             where T: FrameworkElement
        {
            int childNumber = VisualTreeHelper.GetChildrenCount(control);
            for (int i = 0; i < childNumber; i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(control, i);
                FrameworkElement fe = child as FrameworkElement;
                // Not a framework element or is null
                if (fe == null)
                {
                    continue;
                }
                if (child is T && fe.Name == ctrlName)
                {
                    // Found the control so return
                    return (T)child;
                }
                else
                {
                    // Not found it - search children
                    T nextLevel = this.FindChildControl<T>(child, ctrlName);
                    if (nextLevel != null)
                    {
                        return nextLevel;
                    }
                }
            }
            return null;
        }
