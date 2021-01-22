    string tabToRemove = "tabPageName";
    for (int i = 0; i < myTabControl.TabPages.Count; i++)
    {
        if (myTabControl.TabPages[i].Name.Equals(tabToRemove, StringComparison.OrdinalIgnoreCase))
        {
            myTabControl.TabPages.RemoveAt(i);
            break;
        }
    }
