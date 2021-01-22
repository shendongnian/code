	using System.ComponentModel;
	using System.Reflection;
	using System.Threading;
	public class SyncBindingWrapper<T> : INotifyPropertyChanged
	{
		private readonly INotifyPropertyChanged _source;
		private readonly PropertyInfo _property;
		public event PropertyChangedEventHandler PropertyChanged;
		public T Value
		{
			get
			{
				return (T)_property.GetValue(_source, null);
			}
		}
		public SyncBindingWrapper(INotifyPropertyChanged source, string propertyName)
		{
			_source = source;
			_property = source.GetType().GetProperty(propertyName);
			source.PropertyChanged += OnSourcePropertyChanged;
		}
		private void OnSourcePropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName != _property.Name)
			{
				return;
			}
			PropertyChangedEventHandler propertyChanged = PropertyChanged;
			if (propertyChanged == null)
			{
				return;
			}
			SynchronizationContext.Current.Send(state => propertyChanged(this, e), null);
		}
	}
