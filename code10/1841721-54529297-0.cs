    using System;
    using System.Globalization;
    using System.Windows.Data;
    using System.Windows.Media;
    [ValueConversion( typeof( string ), typeof( string ) )]
    public class NoWhiteSpaceTextConverter : IValueConverter
    {
        public object Convert( object value, Type targetType, object parameter, CultureInfo culture )
        {
            if ( ( value is string ) == false )
            {
                throw new ArgumentNullException( "value should be string type" );
            }
    
            string returnValue = ( value as string );
    
            return returnValue != null ? returnValue.Trim() : returnValue;
        }
    
        public object ConvertBack( object value, Type targetType, object parameter, CultureInfo culture )
        {
            throw new NotImplementedException();
        }
    }
