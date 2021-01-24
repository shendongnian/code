    public partial class MyItemControl : UserControl
    {
        public MyItemControl()
        {
            InitializeComponent();
            Sum = MyItem != null ? MyItem.Num1 + MyItem.Num2 + MyItem.Num3 : 0;
        }
        public MyItem MyItem
        {
            get { return (MyItem)GetValue(MyItemProperty); }
            set { SetValue(MyItemProperty, value); }
        }
        public static readonly DependencyProperty MyItemProperty =
            DependencyProperty.Register("MyItem", typeof(MyItem), typeof(MyItemControl), new PropertyMetadata(null, MyItemPropertyChanged));
        private static void MyItemPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            MyItemControl sender = (MyItemControl)obj;
            sender.Sum = sender.MyItem.Num1 + sender.MyItem.Num2 + sender.MyItem.Num3;
            Console.WriteLine("Update sum");
        }
        public int Sum
        {
            get { return (int)GetValue(SumProperty); }
            set { SetValue(SumProperty, value); }
        }
        private static readonly DependencyProperty SumProperty =
            DependencyProperty.Register("Sum", typeof(int), typeof(MyItemControl), new PropertyMetadata(0));
    }
