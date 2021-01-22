            private void chkbox_Checked(object sender, RoutedEventArgs e)
        {
            DependencyObject dep = e.OriginalSource as DependencyObject;
            while ((dep != null) && !(dep is ListViewItem))
            {
                dep = VisualTreeHelper.GetParent(dep);
            }
            if (dep != null)
            {
                IMyViewModel vm = DataContext as IMyViewModel;
                vm.SelectedThing = (MyListItemViewModel)lst.ItemContainerGenerator.ItemFromContainer(dep);
                vm.DoSomethingCommand.Execute(e.RoutedEvent.Name.ToLower());
            }
        }
