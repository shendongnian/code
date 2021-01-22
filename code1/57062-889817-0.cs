    private void EndEdit(DependencyObject parent)
    {
        LocalValueEnumerator localValues = parent.GetLocalValueEnumerator();
        while (localValues.MoveNext())
        {
            LocalValueEntry entry = localValues.Current;
            if (BindingOperations.IsDataBound(parent, entry.Property))
            {
                BindingExpression binding = BindingOperations.GetBindingExpression(parent, entry.Property);
                if (binding != null)
                {
                    binding.UpdateSource();
                }
            }
        }            
        for(int i=0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
        {
            DependencyObject child = VisualTreeHelper.GetChild(parent, i);
            this.EndEdit(child);
        }
    }
    protected void EndEdit()
    {
        this.EndEdit(this);
    }
