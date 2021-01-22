    private void Tree_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            object SelectedValue;
            if (Tree.SelectedValue == null)
            {
                foreach (object ti in Tree.Items)
                {
                    if (((TreeViewItem)ti).IsSelected)
                    {
                        SelectedValue = ti;
                        break;
                    }
                }
            }
            else
            {
                SelectedValue = Tree.SelectedValue;
            }
        }
