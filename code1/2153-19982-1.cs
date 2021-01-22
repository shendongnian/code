    Class test<T>
    {
        int method1(object Parameter1){
            if(Parameter1 is IConvertible) {
                
                IFormatProvider provider = System.Globalization.CultureInfo.CurrentCulture.GetFormat(typeof(T));
                T temp = Parameter1.ToType(typeof(T), provider);
            } else {
               // Do something else
            }
        }
    }
