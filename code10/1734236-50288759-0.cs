    public partial class MyView : ContentView
    {
        public static readonly BindableProperty IDProperty = BindableProperty.Create(
                                        nameof(ID),
                                        typeof(int),
                                        typeof(MyView),
                                        15);
        public int ID
        {
            get => (int)GetValue(IDProperty);
            set => SetValue(IDProperty, value);
        }
        
        public MyView()
        {
            InitializeComponent();
        }
    }
