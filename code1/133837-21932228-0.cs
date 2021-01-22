    protected void SetEnumProperty<TEnum>(string name, ref TEnum oldEnumValue, TEnum newEnumValue) where TEnum : struct, IComparable, IFormattable, IConvertible
    {
    	if (!(typeof(TEnum).IsEnum)) {
    		throw new ArgumentException("TEnum must be an enumerated type");
    	}
    
    	if (oldEnumValue.CompareTo(newEnumValue) != 0) {
    		oldEnumValue = newEnumValue;
    		if (PropertyChanged != null) {
    			PropertyChanged(this, new PropertyChangedEventArgs(name));
    		}
    		_isChanged = true;
    	}
    }
