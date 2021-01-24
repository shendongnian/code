        private void StackPanel_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox cb = e.OriginalSource as CheckBox;
            if(cb.IsChecked == false)
            {
                return;
            }
            foreach (var item in ((StackPanel)sender).Children)
            {
                if(item != cb)
                {
                    ((CheckBox)item).IsChecked = false;
                }
            }
        }
