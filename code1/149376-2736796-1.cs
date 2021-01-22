    private void GetName(object sender, RoutedEventArgs e)
            {
                TreeViewItem item = (TreeViewItem)sender;
                name = item.Header + "." + name;
                if (!(item.Parent is TreeViewItem))
                {
                    MessageBox.Show(name);
                }
                
            }
