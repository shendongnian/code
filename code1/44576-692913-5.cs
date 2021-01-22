      private void SpeedSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (this.IsInitialized)
            {
                Storyboard sb = (Storyboard)rc.Resources["spin"];
                sb.Begin();
            }
        }
