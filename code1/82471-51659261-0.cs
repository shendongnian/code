	protected bool TrySetProperty<T>(Action<T> property, T newValue, T oldValue, [CallerMemberName] string propertyName = null)
	{
		if (EqualityComparer<T>.Default.Equals(oldValue, newValue))
		{
			return false;
		}
		property(newValue);
		RaisePropertyChanged(propertyName);
		return true;
	}
