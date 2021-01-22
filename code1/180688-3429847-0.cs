    private void removeError_Click(object sender, RoutedEventArgs e) {
        FrameworkElement fe = sender as FrameworkElement;
        if (null != fe) {
            _observableCollection.Remove((YourType)fe.DataContext);
    
        }
    }
