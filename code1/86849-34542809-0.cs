	public class MyTraceListener : TraceListener, INotifyPropertyChanged
	{
		private readonly StringBuilder _builder;
		public MyTraceListener()
		{
			_builder = new StringBuilder();
		}
		public string Trace => _builder.ToString();
		public override void Write(string message)
		{
			_builder.Append(message);
			OnPropertyChanged(new PropertyChangedEventArgs("Trace"));
		}
		public override void WriteLine(string message)
		{
			_builder.AppendLine(message);
			OnPropertyChanged(new PropertyChangedEventArgs("Trace"));
		}
		#region INotifyPropertyChanged Members
		public event PropertyChangedEventHandler PropertyChanged;
		#endregion
		protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
		{
			PropertyChanged?.Invoke(this, e);
		}
	}
