    public class MyMultiConverter : IMultiValueConverter
	{
		public object Convert(object[] values, Type targetType, 
                object parameter, CultureInfo culture)
		{
			string ret = null;
			if(values.Count() > 1)
			{
				string value1 = values[0] as string;
				string value2 = values[1] as string;
				ret = value1 + value2;
			}
			return ret;
		}
		public object[] ConvertBack(object value, Type[] targetTypes, 
                object parameter, CultureInfo culture)
		{
		}
	}
