    using System;
    using System.Globalization;
    using System.Windows.Data;
    using System.Windows.Markup;
    namespace wpf_99
    {
    public class CurrencyFormatConverter : MarkupExtension, IValueConverter
    {
    // public double Multiplier { get; set; } You could pass parameters to properties.
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol + System.Convert.ToDecimal(value).ToString("0.##");
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string input = value.ToString();
            if(!char.IsDigit(input[0]))
            {
                input= input.Substring(1);
            }
            if(input.Length == 0)
            {
                return 0;
            }
            return Decimal.Parse(input);
        }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
    }
