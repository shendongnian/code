	/// <summary>
	/// Provides for two way binding between a TestErrors Flag Enum property and a boolean value.
	/// TODO: make this more generic and add it to the converter dictionary if possible
	/// </summary>
	public class TestActionFlagValueConverter : IValueConverter {
		private TestErrors target;
		public TestActionFlagValueConverter() {
		}
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
			TestErrors mask = (TestErrors)parameter;
			this.target = (TestErrors)value;
			return ((mask & this.target) != 0);
		}
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
			this.target ^= (TestErrors)parameter;
			return this.target;
		}
	}
