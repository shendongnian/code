	public interface IWrappedParameter<T>
	{
		T Value { get; }
	}
	public class PasswordBoxWrapper : IWrappedParameter<string>
	{
		private readonly PasswordBox _source;
		public string Value
		{
			get { return _source != null ? _source.Password : string.Empty; }
		}
		public PasswordBoxWrapper(PasswordBox source)
		{
			_source = source;
		}
	}
	public class PasswordBoxConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			// Implement type and value check here...
			return new PasswordBoxWrapper((PasswordBox)value);
		}
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new InvalidOperationException("No conversion.");
		}
	}
