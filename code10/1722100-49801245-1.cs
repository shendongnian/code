        private void menu_item_function(object sender, RoutedEventArgs e)
        {
            // Get the viewmodel from the DataContext
            MainWindowViewModel viewmodel = DataContext as MainWindowViewModel;
            // Call command from viewmodel     
            if ((viewmodel != null) && (viewmodel.View_Model_Function.CanExecute(this)))
            {
                viewmodel.View_Model_Function.Execute(this);
            }
        }
