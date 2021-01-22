        public IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject 
        { 
            if (depObj != null) 
            {
                int depObjCount = VisualTreeHelper.GetChildrenCount(depObj); 
                for (int i = 0; i <depObjCount; i++) 
                { 
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i); 
                    if (child != null && child is T) 
                    { 
                        yield return (T)child; 
                    }
                    if (child is GroupBox)
                    {
                        GroupBox gb = child as GroupBox;
                        Object gpchild = gb.Content;
                        if (gpchild is T)
                        {
                            yield return (T)child; 
                            child = gpchild as T;
                        }
                    }
                    foreach (T childOfChild in FindVisualChildren<T>(child)) 
                    { 
                        yield return childOfChild; 
                    } 
                }
            }
        } 
