        public static DependencyObject FindInVisualTreeDown(DependencyObject obj, Type type)
        {
            if (obj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                    
                    if (child.GetType() == type)
                    {
                        return child;
                    }
                    DependencyObject childReturn = FindInVisualTreeDown(child, type);
                    if (childReturn != null)
                    {
                        return childReturn;
                    }
                }
            }
            return null;
        }
