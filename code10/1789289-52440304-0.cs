    class Class3
    {
        private static string count;
        public static string Count
        {
            get { return count; }
            set
            {
                if (value != count)
                {
                    count = value;
                    OnStaticPropertyChanged(nameof(Count));
                }
            }
        }
        public static event PropertyChangedEventHandler StaticPropertyChanged;
        private static void OnStaticPropertyChanged(string propertyName)
        {
            StaticPropertyChanged?.Invoke(null, new PropertyChangedEventArgs(propertyName));
        }
    }
