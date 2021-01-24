    public class TimeToDelayConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int.TryParse(value.ToString(), out int time);
            var span = TimeSpan.FromSeconds(time);
            if (string.IsNullOrWhiteSpace(value.ToString()) || span.Equals(TimeSpan.MinValue))
            {
                return null;
            }
            else
            {
                return TimeSpanFormatConverter.SecondsToDelay(time);
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class TimeSpanFormatConverter : IValueConverter
    {
        public static TrainDelay SecondsToDelay(int time)
        {
            if (time > 0)
            {
                return TrainDelay.Delayed;
            }
            else if (time < 0)
            {
                return TrainDelay.InAdvance;
            }
            else
            {
                return TrainDelay.OnTime;
            }
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int.TryParse(value.ToString(), out int time);
            //  Don't assign this back to value. Assign it to a new variable that's properly 
            //  typed, so you don't need to cast it. 
            var span = TimeSpan.FromSeconds(time);
            if (string.IsNullOrWhiteSpace(value.ToString()) || span.Equals(TimeSpan.MinValue))
            {
                return "––:––";
            }
            else
            {
                //  No need to copy and paste the same code three times. 
                var timeStr = ((span < TimeSpan.Zero) ? "-" : "") + span.ToString(@"mm\:ss");
                return $"{SecondsToDelay(time)}  {timeStr}";
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
