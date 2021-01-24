       public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            public static DependencyProperty MyDateProperty = DependencyProperty.Register("MyDate", typeof(DateTime), typeof(MainWindow), new FrameworkPropertyMetadata(new PropertyChangedCallback(MyDate_Changed)));
    
            public DateTime MyDate  
            {
                get { return (DateTime)GetValue(MyDateProperty); }
                set { SetValue(MyDateProperty, value); }
            }
    
    
            private static void MyDate_Changed(DependencyObject o, DependencyPropertyChangedEventArgs args)
            {
                MainWindow thisClass = (MainWindow)o;
                thisClass.SetMyDate();
            }
    
            private void SetMyDate()
            {
                //Put Instance MyDate Property Changed code here
            }
    
            private void btnSetDateToToday_Click(object sender, RoutedEventArgs e)
            {
                MyDate = DateTime.Now;
            }
    
            private void btnSetDateToPast_Click(object sender, RoutedEventArgs e)
            {
                MyDate = DateTime.Now.AddDays(-10);
            }
        }
