    public partial class MainWindow : Window {
        private ViewModel _model = new ViewModel();
    
        public MainWindow() {
            InitializeComponent();
            DataContext = _model;
        }
    
        private void Button_Click(object sender, RoutedEventArgs e) {
            _model.Run();
        }
    }
    <Window x:Class="WpfApplication1.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            Title="MainWindow" Height="350" Width="525">
        <Grid>
            <Button Click="Button_Click"
                    Content="Run"
                    IsEnabled="{Binding IsIdle}" />
        </Grid>
    </Window>
    public class ViewModel : INotifyPropertyChanged {
    
        private bool _isIdle = true;
    
        public bool IsIdle {
            get { return _isIdle; }
            set {
                _isIdle = value;
                OnPropertyChanged("IsIdle");
            }
        }
    
        public void Run() {
            ThreadPool.QueueUserWorkItem((state) => {
                IsIdle = false;
                Thread.Sleep(10000);
                IsIdle = true;
            });
        }
    
        #region INotifyPropertyChanged Implementation
    
        protected void OnPropertyChanged(string propertyName) {
            PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if (propertyChanged != null) {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        #endregion
    }
