    using System;
    using System.Windows.Data;
    
    namespace WpfApp1
    {
        public class DoubleModifierConverter : IValueConverter
        {
            public double Modifier { get; set; }
            public Operator Operator { get; set; } = Operator.Addition;
    
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                if (!(value is double doubleValue))
                    throw new InvalidCastException();
    
                switch (Operator)
                {
                    case Operator.Addition:
                        return doubleValue + Modifier;
                    case Operator.Substraction:
                        return doubleValue - Modifier;
                    case Operator.Multiplication:
                        return doubleValue * Modifier;
                    case Operator.Division:
                        return doubleValue / Modifier;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                if (!(value is double doubleValue))
                    throw new InvalidCastException();
    
                switch (Operator)
                {
                    case Operator.Addition:
                        return doubleValue - Modifier;
                    case Operator.Substraction:
                        return doubleValue + Modifier;
                    case Operator.Multiplication:
                        return doubleValue / Modifier;
                    case Operator.Division:
                        return doubleValue * Modifier;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    
        public enum Operator
        {
            Addition = 0,
            Substraction = 1,
            Multiplication = 2,
            Division = 3,
        }
    }
