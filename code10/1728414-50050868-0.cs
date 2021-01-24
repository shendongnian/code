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
            else if (time > 0)
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
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
