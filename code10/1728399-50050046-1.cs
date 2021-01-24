        public MainWindow()
        {
            InitializeComponent();
            FileValidator = ValidateMinFile;
        }
        #region FileValidator Property
        public ExtraValidation FileValidator
        {
            get { return (ExtraValidation)GetValue(FileValidatorProperty); }
            set { SetValue(FileValidatorProperty, value); }
        }
        public static readonly DependencyProperty FileValidatorProperty =
            DependencyProperty.Register(nameof(FileValidator), typeof(ExtraValidation), typeof(MainWindow),
                new PropertyMetadata(null));
        #endregion FileValidator Property
        public Tuple<bool, string> ValidateMinFile(FileInfo f) // ExtraValidation delegate
        {
            //  Breakpoint here
            return new Tuple<bool, string>(false, "blah");
        }
