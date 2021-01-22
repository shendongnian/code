    public class PersonInListConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			string name = (string)value;
			List<Person> persons = (parameter as ObjectDataProvider).ObjectInstance as List<Person>;
			return persons.Exists(person => name.Equals(person.Name));
		}
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
