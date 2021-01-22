	public class NotifyValue<T>
	{
		public static implicit operator T(NotifyValue<T> item)
		{
			return item.Value;
		}
		public NotifyValue(object parent, T value = default(T), PropertyChangingEventHandler changing = null, PropertyChangedEventHandler changed = null, params object[] dependenies)
		{
			_parent = parent;
			_propertyChanged = changed;
			_propertyChanging = changing;
			if (_propertyChanged != null)
			{
				_propertyChangedArg =
					dependenies.OfType<PropertyChangedEventArgs>()
					.Union(
						from d in dependenies.OfType<string>()
						select new PropertyChangedEventArgs(d)
					);
			}
			if (_propertyChanging != null)
			{
				_propertyChangingArg =
					dependenies.OfType<PropertyChangingEventArgs>()
					.Union(
						from d in dependenies.OfType<string>()
						select new PropertyChangingEventArgs(d)
					);
			}
			_PostChangeActions = dependenies.OfType<Action>();
		
		}
		private T _Value;
		public T Value
		{
			get { return _Value; }
			set
			{
				SetValue(value);
			}
		}
		public bool SetValue(T value)
		{
			if (!EqualityComparer<T>.Default.Equals(_Value, value))
			{
				OnPropertyChnaging();
				_Value = value;
				OnPropertyChnaged();
				foreach (var action in _PostChangeActions)
				{
					action();
				}
				return true;
			}
			else
				return false;
		}
		private void OnPropertyChnaged()
		{
			var handler = _propertyChanged;
			if (handler != null)
			{
				foreach (var arg in _propertyChangedArg)
				{
					handler(_parent, arg);
				}			
			}
		}
		private void OnPropertyChnaging()
		{
			var handler = _propertyChanging;
			if(handler!=null)
			{
				foreach (var arg in _propertyChangingArg)
				{
					handler(_parent, arg);
				}
			}
		}
		private object _parent;
		private PropertyChangedEventHandler _propertyChanged;
		private PropertyChangingEventHandler _propertyChanging;
		private IEnumerable<PropertyChangedEventArgs> _propertyChangedArg;
		private IEnumerable<PropertyChangingEventArgs> _propertyChangingArg;
		private IEnumerable<Action> _PostChangeActions;
	}
