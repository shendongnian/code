    protected void ResetTextBoxes(Control parent)
    {
        if(parent is TextBox)
        {
            ((TextBox)parent).Text = string.Empty;
        }
    
        foreach(Control child in parent.Controls)
        {
            if (child is TextBox)
            {
                ((TextBox)child).Text = string.Empty;
            }
    
            ResetTextBoxes(child);
        }
    }
