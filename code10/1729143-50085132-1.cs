	using System;
	using System.Globalization;
	using System.Windows;
	using System.Windows.Data;
	namespace YourNameSpace
	{
		public class ClipConverter : IMultiValueConverter
		{
			public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
			{
				return new Rect(0, 0, System.Convert.ToDouble(values[0]), System.Convert.ToDouble(values[1]));
			}
			public object[] ConvertBack(object value, Type[] targetType, object parameter, CultureInfo culture)
			{
				return null;
			}
		}
	}
