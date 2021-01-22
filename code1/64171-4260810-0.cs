		protected bool SetProperty<T>( ref T backingField, T value, string propertyName )
		{
			var change = !IsReadOnly && !EqualityComparer<T>.Default.Equals( backingField, value );
			if ( change ) {
				backingField = value;
				OnPropertyChanged( propertyName );
			}
			return change;
		}
