    private bool isdragging = false;
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            mySlider.Value += 1;
        }
        private void mySlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (isdragging)
                tboxValue.Text = mySlider.Value.ToString();
        }
        private void mySlider_DragStarted(object sender, System.Windows.Controls.Primitives.DragStartedEventArgs e)
        {
            isdragging = true;
        }
        private void mySlider_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            isdragging = false;
        }
