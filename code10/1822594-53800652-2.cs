    public class CurrencyFormatConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) =>
            System.Convert.ToDecimal(value).ToCurrency(culture);
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (Type.GetTypeCode(targetType))
            {
                case TypeCode.Decimal:
                    return Decimal.TryParse(value.ToString(), NumberStyles.Currency, culture, out var @decimal)
                        ? @decimal
                        : DependencyProperty.UnsetValue;
                case TypeCode.Double:
                    return Double.TryParse(value.ToString(), NumberStyles.Currency, culture, out var @double)
                        ? @double
                        : DependencyProperty.UnsetValue;
                case TypeCode.Int16:
                    return Int16.TryParse(value.ToString(), NumberStyles.Currency, culture, out var int16)
                        ? int16
                        : DependencyProperty.UnsetValue;
                case TypeCode.Int32:
                    return Int32.TryParse(value.ToString(), NumberStyles.Currency, culture, out var int32)
                        ? int32
                        : DependencyProperty.UnsetValue;
                case TypeCode.Int64:
                    return Int64.TryParse(value.ToString(), NumberStyles.Currency, culture, out var int64)
                        ? int64
                        : DependencyProperty.UnsetValue;
                case TypeCode.Single:
                    return Single.TryParse(value.ToString(), NumberStyles.Currency, culture, out var single)
                        ? single
                        : DependencyProperty.UnsetValue;
                case TypeCode.UInt16:
                    return UInt16.TryParse(value.ToString(), NumberStyles.Currency, culture, out var uint16)
                        ? uint16
                        : DependencyProperty.UnsetValue;
                case TypeCode.UInt32:
                    return UInt32.TryParse(value.ToString(), NumberStyles.Currency, culture, out var uint32)
                        ? uint32
                        : DependencyProperty.UnsetValue;
                case TypeCode.UInt64:
                    return UInt64.TryParse(value.ToString(), NumberStyles.Currency, culture, out var uint64)
                        ? uint64
                        : DependencyProperty.UnsetValue;
                default:
                    throw new NotSupportedException($"Converting currency string to target type {targetType} is not supported.");
            }
        }
        public override object ProvideValue(IServiceProvider serviceProvider) => this;
    }
