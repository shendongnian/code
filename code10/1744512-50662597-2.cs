    public class EToastTypeToBrushConverter : IValueConverter
    {
        public Brush Error { get; set; }
        public Brush Info { get; set; }
        public Brush Success { get; set; }
        public Brush Warning { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is EToastType type)
            {
                switch (type)
                {
                    case EToastType.Error:
                        return Error;
                    case EToastType.Info:
                        return Info;
                    case EToastType.Success:
                        return Success;
                    case EToastType.Warning:
                        return Warning;
                }
            }
            return null;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotSupportedException();
    }
