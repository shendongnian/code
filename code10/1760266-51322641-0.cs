    private void ChildContextMenu_Click(object sender, RoutedEventArgs e)
    {
        MenuItem mi = sender as MenuItem;
        if (mi != null)
        {
            ContextMenu cm = mi.Parent as ContextMenu;
            if (cm != null)
            {
                StackPanel sp = cm.PlacementTarget as StackPanel;
                if (sp != null)
                {
                    Panel parentSp = sp.Parent as Panel;
                    if (parentSp != null)
                        parentSp.Children.Remove(sp);
                }
            }
        }
    }
