        List<string> lsSelectItmes = new List<string>();
        foreach (ListItem item in toListBox.Items)
            if (item.Selected)
                lsSelectItmes.Add(item.Value);
    
         string strSelectedValues = string.Join(",", lsSelectItmes.ToArray());
    /// Return [Tag1,Tag2,...,N]
