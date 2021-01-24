    public partial class MainPage : ContentPage
	{
        public ObservableCollection<MyObject> MyItemsSource { get; set; }
		public MainPage()
		{
			InitializeComponent();
            MyItemsSource = new ObservableCollection<MyObject>
            {
                new MyObject(1.14),
                new MyObject(1.14),
                new MyObject(1.14),
                new MyObject(1.14),
                new MyObject(1.14),
            };
            BindingContext = this;
        }
        void ButtonClicked(object sender, EventArgs e)
        {
            var rnd = new Random();
            var myObject = MyItemsSource[rnd.Next(0, MyItemsSource.Count)];
            myObject.Amount = 5.09;
        }
    }
