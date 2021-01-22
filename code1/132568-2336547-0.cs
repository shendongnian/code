    public class BindableObject : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		public void PropertyChange(String propertyName)
		{
			VerifyProperty(propertyName);
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		[Conditional("DEBUG")]
		private void VerifyProperty(String propertyName)
		{
			Type type = GetType();
			PropertyInfo info = type.GetProperty(propertyName);
			if (info == null)
			{
				var message = String.Format(CultureInfo.CurrentCulture, "{0} is not a public property of {1}", propertyName, type.FullName);
				//Modified this to throw an exception instead of a Debug.Fail to make it more unit test friendly
				throw new ArgumentOutOfRangeException(propertyName, message);
			}
		}
	}
