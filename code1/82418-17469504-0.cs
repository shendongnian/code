	public class BaseViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		protected void Set<T>(ref T field, T value)
		{
			MethodBase method = new StackFrame(1).GetMethod();
			field = value;
			Raise(method.Name.Substring(4));
		}
		protected void Raise(string propertyName)
		{
			var temp = PropertyChanged;
			if (temp != null)
			{
				temp(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
