    Binding binding = new Binding("SelectedItem")
            {
                Source = treeView, //name of tree view in xaml
                Mode = BindingMode.OneWay
            };
            BindingOperations.SetBinding(DataContext, MyViewModel.SelectedTreeViewItemProperty, binding);
