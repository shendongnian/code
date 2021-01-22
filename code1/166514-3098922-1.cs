        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.DoSomething();
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Right && e.KeyboardDevice.Modifiers == ModifierKeys.Control)
            {
                this.DoSomething();
            }
        }
        private void DoSomething()
        {
            MessageBox.Show("Whatever");
        }
