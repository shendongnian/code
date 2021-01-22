        private void NotificationLinkClick(object sender, RoutedEventArgs e)
        {
            var myDataObject = ((FrameworkElement)sender)
                                                 .DataContext as MyDataObject;
            DoSomeWork(myDataObject);
        }
