      private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (sender != null)
            {
                var treeView = sender as TreeView;
                if (treeView != null)
                {
                    var commandViewModel = treeView.SelectedItem as CommandViewModel;
                    if (commandViewModel != null)
                    {
                        var mi = commandViewModel.Command.GetType().GetMethod("Execute");
                        mi.Invoke(commandViewModel.Command, new Object[] {null});
                    }
                }
            }
        }
