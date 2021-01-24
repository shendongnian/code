    private void NotiifcationGrid_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (canvas.Visibility == Visibility)
            {
                Storyboard1.Begin();
            }
            else
            {
                canvas.Visibility = Visibility;
                Storyboard2.Begin();
            }
        }
        private void Storyboard1_Completed(object sender, object e)
        {
            canvas.Visibility = Visibility.Collapsed;
        }
