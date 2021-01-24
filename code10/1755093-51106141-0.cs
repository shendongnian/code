     public class StringFormatConverter : MarkupExtension, IMultiValueConverter
        {
            public string StringFormat { get; set; } = @"({0}) {1}";
    
            public string PlaceHolder { get; set; } = "Empty";
    
            public override object ProvideValue(IServiceProvider serviceProvider) => this;
    
            public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
            {
                return string.Format(StringFormat, GetValues(values));
            }
    
            private IEnumerable<string> GetValues(object[] values)
            {
                foreach (var value in values)
                    yield return value == DependencyProperty.UnsetValue || value == null ? PlaceHolder : value.ToString();
            }
    
            public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
            {
                return new[] { Binding.DoNothing, Binding.DoNothing };
            }
        }
