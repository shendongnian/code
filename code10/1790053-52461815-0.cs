        public T FindVisualChildOrContentByType<T>(DependencyObject parent)
            where T : DependencyObject
        {
            if(parent == null)
            {
                return null;
            }
            if(parent.GetType() == typeof(T))
            {
                return parent as T;
            }
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                
                if(child.GetType() == typeof(T))
                {
                    return child as T;
                }
                else
                {
                    T result = FindVisualChildOrContentByType<T>(child);
                    if (result != null)
                        return result;
                }
            }
            if(parent is ContentControl contentControl)
            {
                return this.FindVisualChildOrContentByType<T>(contentControl.Content as DependencyObject);
            }
            return null;
        }
