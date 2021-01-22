    <Image Source="{Binding MyImagePath}" />
            
        public static readonly DependencyProperty MyImagePathProperty = DependencyProperty.Register("MyImagePath", typeof(string), typeof(ClassName), new PropertyMetadata("pack://application:,,,/YourAssembly;component//icons/icon1.png"));
        
        public string MyImagePath
        {
            get { return (string)GetValue(MyImagePathhProperty); }
            set { SetValue(MyImagePathProperty, value); }
        }
