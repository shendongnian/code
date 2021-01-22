    Class test<T>
    {
        int method1(IConvertible Parameter1){
            IFormatProvider provider = System.Globalization.CultureInfo.CurrentCulture.GetFormat(typeof(T));
            T temp = Parameter1.ToType(typeof(T), provider);
        }
    }
