    class TimeSpanConverter : IValueConverter
	{
		public int Hours { get; set; }
		public int Minutes { get; set; }
		public int Seconds { get; set; }
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			string strParam = (string)parameter;
			TimeSpan ts = (TimeSpan)value;
			switch(strParam.ToLower())
			{
				case "hours":
					return ts.Hours.ToString();
				case "minutes":
					return ts.Minutes.ToString();
				case "seconds":
					return ts.Seconds.ToString();
			}
			return "0";
		}
		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			string strParam = (string)parameter;
			int intVal = int.Parse((string)value);
			switch (strParam.ToLower())
			{
				case "hours":
					Hours = intVal;
					break;
				case "minutes":
					Minutes = intVal;
					break;
				case "seconds":
					Seconds = intVal;
					break;
			}
			return new TimeSpan(Hours, Minutes, Seconds);
		}
	}
