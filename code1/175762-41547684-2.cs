    [ValueConversion(typeof(DateTime), typeof(string))]
    public class DateTimeToStringConverter : Markup.MarkupExtension, IValueConverter {
	    public DateTimeToStringConverter() : base() {
            DisplayStyle = Kind.DateAndTime;
            DisplaySeconds = true;
        }
    	#region IValueConverter
    	public object Convert(object value, Type targetType, object parameter, Globalization.CultureInfo culture) {
    		if (value == null) return string.Empty;
    		if (!value is DateTime) throw new ArgumentException("The value's type has to be DateTime.", "value");
    
    		DateTime dateTime = (DateTime)value;
    
    		string returnValue = string.Empty;
    
    		switch (DisplayStyle) {
    			case Kind.Date:
    				returnValue = dateTime.ToShortDateString();
    				break;
    			case Kind.Time:
    				returnValue = dateTime.ToLongTimeString();
    				break;
    			case Kind.DateAndTime:
    				returnValue = dateTime.ToString();
    				break;
    		}
    
    		if (!DisplaySeconds) {
    			int index = returnValue.LastIndexOf(':');
    
    			if (index > -1) {
    				returnValue = returnValue.Remove(index, 3);
    			}
    		}
    
    		return returnValue;
    	}
    
    	public object ConvertBack(object value, Type targetType, object parameter, Globalization.CultureInfo culture) {
    		throw new NotSupportedException();
    	}
    	#endregion
    
    	public override object ProvideValue(IServiceProvider serviceProvider) {
    		return this;
    	}
    
    	#region Properties
    	public Kind DisplayStyle { get; set; }
    
    	public bool DisplaySeconds { get; set; }
    	#endregion
    
    	public enum Kind {
    		Date,
    		Time,
    		DateAndTime
    	}
    }
