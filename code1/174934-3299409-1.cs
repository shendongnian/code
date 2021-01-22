    private bool IsControlAtFront(Control control)
    {
        while (control.Parent != null)
        {
            if (control.Parent.Controls.GetChildIndex(control) == 0)
            {
                control = control.Parent;
                if (control.Parent == null)
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
        return false;
    }
