    public delegate Tuple<bool, string> ExtraValidation(FileInfo fi);
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }
        #region FileValidator Property
        public ExtraValidation FileValidator
        {
            get { return (ExtraValidation)GetValue(FileValidatorProperty); }
            set { SetValue(FileValidatorProperty, value); }
        }
        public static readonly DependencyProperty FileValidatorProperty =
            DependencyProperty.Register(nameof(FileValidator), typeof(ExtraValidation), typeof(UserControl1),
                new PropertyMetadata(null, FileValidator_PropertyChanged));
        #endregion FileValidator Property
        protected static void FileValidator_PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //  I just put this here for testing: If it's non-null, it'll be called. 
            //  I set a breakpoint in the MainWindow method to detect the call. 
            (d as UserControl1).FileValidator?.Invoke(null);
        }
    }
