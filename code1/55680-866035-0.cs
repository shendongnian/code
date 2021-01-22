        public Page()
        {
            InitializeComponent();
            App.Current.Host.Content.Resized += (s, e) =>
            {
                
                // Place here your layour resize code...
                this.Width = App.Current.Host.Content.ActualWidth;
                this.Height = App.Current.Host.Content.ActualHeight;
            };
            
        }
