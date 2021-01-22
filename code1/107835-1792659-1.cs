    public class SelectEmployeeConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, 
            object parameter, CultureInfo culture)
        {
            Debug.Assert(values.Length >= 2);
            // change this type assumption
            var employees = values[0] as ICollection<Employee>;
            var index = Convert.ToInt32(values[1]);
            // and check bounds
            if (employees != null) return employees[index];
            return Binding.DoNothing;
        }
        public object[] ConvertBack(object value, Type[] targetTypes,
            object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
