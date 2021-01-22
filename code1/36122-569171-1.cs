    public class VisibilityConverter : IMultiValueConverter
    {
      public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
      {
        Visibility text1Vis = (Visibility)values[0];
        Visibility text2Vis = (Visibility)values[1];
        Visibility text3Vis = (Visibility)values[2];
        if (text1Vis == text2Vis == text3Vis == Visibility.Collapsed)
          return Visibility.Collapsed;
        return Visibility.Visible;
      }
    }
