        public class ValidationExceptionConverter : IValueConverter
        {
            #region IValueConverter Members
    
            // From string to 
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                ValidationError error = value as ValidationError;
                if (error == null)
                    return null;
    
                Exception exception = error.Exception;
                if (exception == null)
                {
                    return error.ErrorContent;
                }
                else
                {
                    // Find the innermost exception
                    while (exception.InnerException != null)
                        exception = exception.InnerException;
    
                    // Use it's message as output
                    return exception.Message;
                }
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
    
            #endregion
        }
