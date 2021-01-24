        public partial class UsbFileSelector : Window
        {
            public static readonly DependencyProperty UsbFilesProperty = 
                DependencyProperty.Register("UsbFiles", typeof(ObservableCollection<UsbFile>), typeof(UsbFileSelector));
            public ObservableCollection<UsbFile> UsbFiles 
            {
                get { return (ObservableCollection<UsbFile>) GetValue(UsbFilesProperty); }
                set { SetValue(UsbFilesProperty, value); }
            }
            public UsbFileSelector()
            {
                InitializeComponent();
            }
        }
