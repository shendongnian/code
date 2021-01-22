    public static List<TChildType> FindChildrenOfType<TChildType>(this Control currentControl)
        where TChildType : Control
    {
        var childList = new List<TChildType>();
        foreach (Control childControl in currentControl.Controls)
        {
            if (childControl is TChildType)
            {
                childList.Add((TChildType)childControl);
            }
            
            childList.AddRange(childControl.FindChildrenOfType<TChildType>());
            
        }
        return childList;
    }
