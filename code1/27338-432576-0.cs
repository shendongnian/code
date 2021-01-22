        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            ListBoxItem lstItem = ((FrameworkElement)b.TemplatedParent).TemplatedParent as ListBoxItem;
            int index = lstBox.ItemContainerGenerator.IndexFromContainer(lstItem);
        }
