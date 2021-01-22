       public static DependencyObject GetScrollViewer(this DependencyObject o)
            {
                // Return the DependencyObject if it is a ScrollViewer
                if (o is ScrollViewer)
                { return o; }
    
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(o); i++)
                {
                    var child = VisualTreeHelper.GetChild(o, i);
    
                    var result = GetScrollViewer(child);
                    if (result == null)
                    {
                        continue;
                    }
                    else
                    {
                        return result;
                    }
                }
    
                return null;
            }
