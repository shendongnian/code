    public class MyValueConverter : IValueConverter
    {
        private readonly IUserService _userService;
        public MyValueConverter(IUserService userService)
        {
            _userService = userService;
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var isUserLoggedIn = _userService.IsLoggedIn;
            if (isUserLoggedIn)
                // Do some conversion
            else
                // Do some other conversion
            ...
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
