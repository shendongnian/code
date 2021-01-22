    using System;
    using System.Collections;
    using System.Globalization;
    using System.Linq;
    using System.Windows.Data;
    
    namespace MyNameSpace
    {
        public class ToTypeEqualityWrapper : IValueConverter
        {
            public class TypeEqualityWrapper
            {
                public object Value { get; set; }
    
                public TypeEqualityWrapper(object value)
                {
                    Value = value;
                }
    
                public override bool Equals(object obj)
                {
                    var otherWrapper = obj as TypeEqualityWrapper;
                    if (otherWrapper == null)
                        return false;
    
                    var result = Value.GetType().FullName == otherWrapper.Value.GetType().FullName;
                    return result;
                }
            }
    
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                var list = value as IList;
                if (list != null)
                {
                    return (from object item in list select new TypeEqualityWrapper(item)).Cast<object>().ToList();
                }
    
                return new TypeEqualityWrapper(value);
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                var wrapper = value as TypeEqualityWrapper;
                if(wrapper != null)
                    return wrapper.Value;
    
                return value;
            }
        }
    }
