        private async void Horizontal_AxisChanged(object sender, AxisChangedEventArgs e)
        {
            DateTimeAxis horizontal = sender as DateTimeAxis;
            if(horizontal.Scale > 100)
            {
                horizontal.IntervalType = DateTimeIntervalType.Hours;
            }
            else if(horizontal.Scale < 100)
            {
                horizontal.IntervalType = DateTimeIntervalType.Days;
            }
        }
