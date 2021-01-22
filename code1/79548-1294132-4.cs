    private void Selection_Changed(object sender, RoutedEventArgs e)
            {
                Items x = controltree.SelectedItem as Items;
    
                if (x.IsLeaf.Equals("leaf"))
                    _parent.RaiseChange(x.Parent+","+x.Name);
            }
     
