        private void MyTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) SomeButton_Click(this, null);
        }
        private void SomeButton_Click(object sender, RoutedEventArgs e)
        {
            ICommand cmd = SomeButton.Command;
            if (cmd.CanExecute(null))
            {
                cmd.Execute(null);
            }
        }
