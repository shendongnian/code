    public class SelectEmployeeConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, 
            object parameter, CultureInfo culture)
        {
            Debug.Assert(values.Length >= 2);
            // change this type assumption
            var array = values[0] as Array;
            var list = values[0] as IList;
            var enumerable = values[0] as IEnumerable;
            var index = Convert.ToInt32(values[1]);
            // and check bounds
            if (array != null && index >= 0 && index < array.GetLength(0))
                return array.GetValue(index);
            else if (list != null && index >= 0 && index < list.Count)
                return list[index];
            else if (enumerable != null && index >= 0)
            {
                int ii = 0;
                foreach (var item in enumerable)
                {
                    if (ii++ == index) return item;
                }
            }
            return Binding.DoNothing;
        }
        public object[] ConvertBack(object value, Type[] targetTypes,
            object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
