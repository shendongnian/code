    /// <summary>
    /// Finds a Control recursively. Note finds the first match and exists
    /// </summary>
    /// <param name="ContainerCtl"></param>
    /// <param name="IdToFind"></param>
    /// <returns></returns>
    public static Control FindControlRecursive(Control Root, string Id)
    {
        if (Root.ID == Id)
            return Root;
     
        foreach (Control Ctl in Root.Controls)
        {
            Control FoundCtl = FindControlRecursive(Ctl, Id);
            if (FoundCtl != null)
                return FoundCtl;
        }
     
        return null;
    }
