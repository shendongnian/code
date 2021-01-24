    public partial class MyFormattedTextControl : UserControl, INotifyPropertyChanged
    {
        public MyFormattedTextControl()
        {
            InitializeComponent();
            stack.DataContext = this;
        }
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(MyFormattedTextControl), new PropertyMetadata(null, OnTextPropertyChanged));
        private static void OnTextPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var ctrl = (MyFormattedTextControl)d;
            var t = (string)e.NewValue;
            var regex = new Regex("(?<Part1>.)(?<Part2>.)(?<Part3>.{7})(?<Part4>.)");
            var m = regex.Match(t);
            if (!m.Success)
            {
                ctrl.Part1 = ctrl.Part2 = ctrl.Part3 = ctrl.Part4 = string.Empty;
            }
            else
            {
                ctrl.Part1 = m.Groups["Part1"].Value;
                ctrl.Part2 = m.Groups["Part2"].Value;
                ctrl.Part3 = m.Groups["Part3"].Value;
                ctrl.Part4 = m.Groups["Part4"].Value;
            }
        }
        private string part1;
        public string Part1
        {
            get { return part1; }
            set { part1 = value; OnPropertyChanged(); }
        }
        private string part2;
        public string Part2
        {
            get { return part2; }
            set { part2 = value; OnPropertyChanged(); }
        }
        private string part3;
        public string Part3
        {
            get { return part3; }
            set { part3 = value; OnPropertyChanged(); }
        }
        private string part4;
        public string Part4
        {
            get { return part4; }
            set { part4 = value; OnPropertyChanged(); }
        }
        private void OnPropertyChanged([CallerMemberName] string callerMember = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(callerMember));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
