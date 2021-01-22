    public class MarginConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is Thickness)) return new Thickness();
            Thickness retMargin = (Thickness) value;
            List<string> singleMargins = (parameter as string)?.Split(';').ToList() ?? new List<string>();
            singleMargins.ForEach(m => {
                                      switch (m.Split(':').ToList()[0].ToLower().Trim()) {
                                          case "left":
                                              retMargin.Left = double.Parse(m.Split(':').ToList()[1].Trim());
                                              break;
                                          case "top":
                                              retMargin.Top = double.Parse(m.Split(':').ToList()[1].Trim());
                                              break;
                                          case "right":
                                              retMargin.Right = double.Parse(m.Split(':').ToList()[1].Trim());
                                              break;
                                          case "bottom":
                                              retMargin.Bottom = double.Parse(m.Split(':').ToList()[1].Trim());
                                              break;
                                      }
                                  }
                );
            return retMargin;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
