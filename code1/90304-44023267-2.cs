        private void RangeBase_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var slider = sender as Slider;
            if (slider == null) return;
            var progressBar = (ProgressBar)slider.Template.FindName("TrackProgressBar", slider);
            if (progressBar == null) return;
            if (e.NewValue > progressBar.Value)
            {
                slider.Value = progressBar.Value;
                e.Handled = true;
                return;
            }
        }
