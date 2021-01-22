    /// <summary>
    /// Recursive FindControl method, to search a control and all child
    /// controls for a control with the specified ID.
    /// </summary>
    /// <returns>Control if found or null</returns>
    public static Control FindControlRecursive(Control root, string id)
    {
        if (id == string.Empty)
            return null;
        if (root.ID == id)
            return root;
        foreach (Control c in root.Controls)
        {
            Control t = FindControlRecursive(c, id);
            if (t != null)
            {
                return t;
            }
        }
        return null;
    }
