    public static class MyExtensionsWithData
    {
        // declare one of these for each "data slot" you'll be using
        public static readonly DependencyProperty PhoneProperty = 
            RegisterAttached("PhoneNumber", 
                             typeof(string), 
                             typeof(MyExtensionsWithData));
        public static void SetPhoneNumber(this Address address, string phone)
        {
            address.SetValue(PhoneProperty, phone);
        }
        public static string GetPhoneNumber(this Address address)
        {
            return (string)address.GetValue(PhoneProperty);
        }
    }
