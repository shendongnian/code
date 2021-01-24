    public partial class Practice : Window
    {
        // INotifyPropertyChanged implementation is important!
		// Without it, WPF has no way of knowing that you changed your property...
		public class PracticeModel : INotifyPropertyChanged
		{
			private BitmapImage _background;
			public BitmapImage Background 
			{ 
				get => _background;
				set { _background = value; PropertyChanged?.Invoke(nameof(Background)); }
			}
			public event PropertyChangedEventHandler PropertyChanged;
		}
    
        public Practice()
        {
            InitializeComponent();
    
            // DataContext specifies which object the bindings are bound to
            this.DataContext = new PracticeModel();
        }
    }
