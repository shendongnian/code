        private void LabelFreeText_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            LabelFreeText.Focus();//select the control
            e.Handled = true;//don't move the caret anymore
        }
        private void MoveCarretToEnd(object sender, RoutedEventArgs e)
        {
            LabelFreeText.CaretIndex = LabelFreeText.Text.Length;
        }
