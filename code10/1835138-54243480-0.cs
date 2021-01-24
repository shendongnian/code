        public string vmType
        {
            get { return (string)GetValue(vmTypeProperty); }
            set { SetValue(vmTypeProperty, value); viewModel.vmType = vmType; }
        }
        // Using a DependencyProperty as the backing store for vmType.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty vmTypeProperty =
            DependencyProperty.Register("vmType", typeof(string), typeof(UserControl), new PropertyMetadata(null));
