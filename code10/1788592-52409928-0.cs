    Panel panel = Computers.Content as Panel;
    if (panel != null)
    {
        foreach (CheckBox checkBox in panel.Children.OfType<CheckBox>())
        {
            //...
        }
    }
