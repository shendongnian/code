        private void slider_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Point point = e.GetPosition(slider);
            slider.Value = point.X;
        }
