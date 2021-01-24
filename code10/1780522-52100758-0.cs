        private void SomeFunction()
        {
            TreeViewItem chr = new TreeViewItem();
            chr.GotFocus += testing; // Event directly, no wrapper.
        }
        private void testing(object sender, RoutedEventArgs e) // it's RoutedEventArgs, not EventArgs 
        {
            var chr = sender as TreeViewItem; // convert to item
            //do your rest work
        }
