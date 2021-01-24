        protected override void OnAppearing()
        {
            base.OnAppearing();
            UserDialogs.Instance.ShowLoading("Loading...");
        }
        public Inventory()
		{			
            TimeSpan interval = new TimeSpan(0, 0, 3);
            Device.StartTimer(interval,()=> {
                InitializeComponent();
                UserDialogs.Instance.HideLoading();
                return true;
            });          
        }
