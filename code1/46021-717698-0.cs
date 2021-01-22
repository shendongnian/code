    foreach (ListItem li in listbox.Items.ToArray())
    {
        if (li.Selected)
        {
            Controltest2.Remove(li.Value);
        }
    }
