    public Control RecursiveFindControl(Control parent, string idToFind)
    {
        for each (Control child in parent.ChildControls)
        {
            if (child.ID == idToFind)
            {
                return child;
            }
            else
            {
                Control control = RecursiveFindControl(child, idToFind);
                if (control != null)
                {
                    return control;
                }
            }
        }
        return null;
    }
