    namespace Silverlight.Mine
    {
        public class SomeType
        {
            public List<DateTime> SomeDates { get; set; }
            public SomeType()
            {
                SomeDates = new List<DateTime>();
                SomeDates.Add(DateTime.Now.AddDays(-1));
                SomeDates.Add(DateTime.Now);
                SomeDates.Add(DateTime.Now.AddDays(1));
            }
        }
        public class SomeTypeConverter : IValueConverter
        {
            public object Convert(object value,
                           Type targetType,
                           object parameter,
                           CultureInfo culture)
            {
                if (value != null)
                {
                    List<DateTime> myList = (List<DateTime>)value;
                    return myList[0].ToString("dd MMM yyyy");
                }
                else
                {
                     return String.Empty;
                }
            }
            public object ConvertBack(object value,
                                  Type targetType,
                                  object parameter,
                                  CultureInfo culture)
            {
                if (value != null)
                {
                    return (List<DateTime>)value;
                }
                return null;
            }
        }
    }
