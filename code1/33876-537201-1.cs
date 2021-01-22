    public bool SearchChildren(DependencyObject parent, TextBoxOperation op)
    {
        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
        {
            DependencyObject child = VisualTreeHelper.GetChild(parent, i);
    
            TextBox box = child as TextBox;
    
            if (box != null)
            {
                op.Invoke(box);
                return true;
            }
    
            bool found = SearchChildren(child, op);
    
            if (found)
                return true;
        }
    }
