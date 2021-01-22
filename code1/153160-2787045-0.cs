    [ValueConversion(typeof(AcceptationStatusGlobalFlag), typeof(string))]
    public class AcceptationStatusGlobalFlagToIconFilenameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            switch ((AcceptationStatusGlobalFlag)value)
            {
                case AcceptationStatusGlobalFlag.Ready:
                    return "ready.jpg";
                case AcceptationStatusGlobalFlag.NotReady:
                    return "notready.jpg";
                case AcceptationStatusGlobalFlag.AcceptedByAdmin:
                    return "AcceptedByAdmin.jpg";
                default:
                    return null;
            }
            
            // or
            return Enum.GetName(typeof(AcceptationStatusGlobalFlag), value) + ".jpg";
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
