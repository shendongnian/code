        private void DropDownWasOpened(object sender, EventArgs e) {
            var selectedItem = MyComboBox.SelectedItem;
            MyComboBox.SelectedItem = null;
            Dispatcher.BeginInvoke(new Action(() => MyComboBox.SelectedItem = selectedItem));
        }
