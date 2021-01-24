        private static void ScrollValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as MainWindow).UpperTextBox.Margin = new Thickness(-1 * (int)e.NewValue, 0, 0, 0);
            (d as MainWindow).LowerTextBox.Margin = new Thickness(-1 * (int)e.NewValue, 0, 0, 0);
            //(d as MainWindow).UpperTextBox.ScrollToHorizontalOffset((int)e.NewValue * 100);
            //(d as MainWindow).LowerTextBox.ScrollToHorizontalOffset((int)e.NewValue * 100);
        }
