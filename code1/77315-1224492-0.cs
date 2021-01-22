        /// <summary>
        /// Property Dependency Property
        /// </summary>
        public static readonly DependencyProperty PropertyProperty =
            DependencyProperty.Register("Property", typeof(string), typeof(PropertyRelay),
                new FrameworkPropertyMetadata((string)null));
        /// <summary>
        /// --> Enter documentation here.
        /// </summary>
        public string Property
        {
            get { return (string)GetValue(PropertyProperty); }
            set { SetValue(PropertyProperty, value); }
        }
